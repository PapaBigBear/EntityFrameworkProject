﻿using System;

namespace CMDDto.Models
{
    public class ItemDTO
    {
        public Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemNumber { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal WeightInGrams { get; set; }
    }
}
