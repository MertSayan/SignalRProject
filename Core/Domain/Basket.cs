namespace Domain
{
    public class Basket
    {
        public int BasketId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}
