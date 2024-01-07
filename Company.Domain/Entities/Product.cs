namespace Company.Domain.Entities {
    public class Product {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int ProductTypeId { get; set; } //FK ProductType
        public ProductType? ProductType { get; set; } //Navigation Property
    }
}
