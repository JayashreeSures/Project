namespace Cake_palace.models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ImageUrl { get; set; }
        public double ProductPrice { get; set; }
        public double ProductQuantity { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        //public ICollection<CartProductMap>? CartProductMaps { get; } = new List<CartProductMap>();
        //public Order Order { get; set; }

    }
}
