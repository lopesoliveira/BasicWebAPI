namespace Company.Domain.Entities {
    public class OrderLines {
        public int Id { get; set; }
        public int OrderId { get; set; } //fk
        public int ProductId { get; set; } //fk
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }


    }
}
