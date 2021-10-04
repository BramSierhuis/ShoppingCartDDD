using ShoppingCard.Messages.Events;
using System;
using System.Collections.Generic;

namespace ShoppingCard.Core.Abstract
{
    public abstract class AggregateRoot<TId>
    {
        public TId Id { get; protected set; }
        public int Version { get; private set; }
        private readonly IList<IEvent> _events;

        public AggregateRoot()
        {
            _events = new List<IEvent>();
        }

        protected abstract void Mutate(IEvent e);

        protected void Apply<TEvent>(Action<TEvent> action)
            where TEvent : IEvent
        {
            // Create a new instance
            var @event = Activator.CreateInstance<TEvent>();
            action.Invoke(@event);

            // Update the state
            Mutate(@event);

            // Add the event
            _events.Add(@event);
            Version++;
        }

        public void ApplyIf<TEvent>(Func<object, bool> validateFunction, Action<TEvent> successAction)
            where TEvent : IEvent
        {
            var success = validateFunction.Invoke(this);

            if (success)
            {
                Apply(successAction);
            }
        }

        public void Hydrate(IEnumerable<IEvent> events)
        {
            foreach (var @event in events)
            {
                Mutate(@event);
                Version++;
            }
        }
    }
}
