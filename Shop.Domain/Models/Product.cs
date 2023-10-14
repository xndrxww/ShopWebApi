﻿using Shop.Domain.Enums;

namespace Shop.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Size Size { get; set; }
        public ushort Quantity { get; set; }
    }
}
