﻿namespace Domain
{
    public class Table
    {
        public int TableId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<Basket> Baskets { get; set; }
    }
}
