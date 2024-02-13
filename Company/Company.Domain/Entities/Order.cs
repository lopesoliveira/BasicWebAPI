namespace Company.Company.Domain.Entities {
    public class Order {
        public int Id { get; set; }
        public string? BillingAddress { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; } //fk
        public Customer? Customer { get; set; } //nav
    }
}
