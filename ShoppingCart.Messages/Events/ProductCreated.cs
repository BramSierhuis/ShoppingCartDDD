﻿using System;

namespace ShoppingCart.Messages.Events
{
    public class ProductCreated : IEvent
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public long Ean { get; set; }
    }
}
