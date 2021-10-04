using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventStore.Client;
using Newtonsoft.Json;
using ShoppingCart.Core.Abstract;
using ShoppingCart.Core.ValueObjects;

namespace ShoppingCart.Core.AggregateStore
{
    public class AggregateStore : IAggregateStore
    {
        private readonly EventStoreClient _client;

        public AggregateStore(EventStoreClient client) => _client = client;

        public async Task Save<T, TId>(T aggregate) where T : AggregateRoot<TId>
        {
            if (aggregate == null)
                throw new ArgumentNullException(nameof(aggregate));

            var events = aggregate.GetEvents()
                .Select(@event =>
                    new EventData(
                        eventId: Uuid.NewUuid(),
                        type: @event.GetType().Name,
                        data: Serialize(@event),
                        metadata: Serialize(new EventMetadata
                            {ClrType = @event.GetType().AssemblyQualifiedName})
                    ))
                .ToArray();

            if (!events.Any()) return;

            var streamName = GetStreamName<T, TId>(aggregate);

            await _client.AppendToStreamAsync(
            streamName,
            StreamState.Any,
            events);

            aggregate.Flush();
        }

        public async Task<T> Load<T, TId>(TId aggregateId)
            where T : AggregateRoot<TId>
        {
            //TODO: More explicit error
            if (aggregateId == null)
                throw new ArgumentNullException(nameof(aggregateId));

            var streamName = GetStreamName<T, TId>(aggregateId);
            var aggregate = (T) Activator.CreateInstance(typeof(T), true);

            var result = _client.ReadStreamAsync(Direction.Forwards, streamName, StreamPosition.Start);
            
            if (await result.ReadState == ReadState.StreamNotFound)
                throw new StreamNotFoundException($"Stream {streamName} could not be found");

            var events = await result.ToListAsync();

            aggregate.Hydrate(events.Select(resolvedEvent =>
            {
                var meta = JsonConvert.DeserializeObject<EventMetadata>(
                    Encoding.UTF8.GetString(resolvedEvent.Event.Metadata.Span));
                var dataType = Type.GetType(meta.ClrType);
                var jsonData = Encoding.UTF8.GetString(resolvedEvent.Event.Data.Span);
                var data = JsonConvert.DeserializeObject(jsonData, dataType);


                return data;
            }).ToArray());

            return aggregate;
        }

        public async Task<bool> Exists<T, TId>(TId aggregateId)
        {
            var streamName = GetStreamName<T, TId>(aggregateId);

            var result = _client.ReadStreamAsync(Direction.Forwards, streamName, StreamPosition.Start);
            return await result.ReadState != ReadState.StreamNotFound;
        }

        private static byte[] Serialize(object data)
            => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

        private static string GetStreamName<T, TId>(TId aggregateId)
            => $"{typeof(T).Name}-{aggregateId}";

        private static string GetStreamName<T, TId>(T aggregate)
            where T : AggregateRoot<TId>
            => $"{typeof(T).Name}-{aggregate.Id}";
    }
}