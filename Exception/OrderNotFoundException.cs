namespace Cake_palace.Exceptions
{
    public class OrderNotFoundException : ApplicationException
    {
        public OrderNotFoundException(string msg) : base(msg)
        {
            
        }
        public OrderNotFoundException()
        {
            
        }
    }
}
