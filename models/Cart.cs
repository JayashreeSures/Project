namespace Cake_palace.models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public Product? Product { get; set; }
        public User? User { get; set; }
        //public Order? Order {  get; set; }

        //public ICollection<CartProductMap>? CartProductMaps { get; } = new List<CartProductMap>();
    }
}
