namespace Cake_palace.models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? MobileNo { get; set; }
        public int? PostelCode { get; set; }

        //public Cart? Cart { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
    }
}
