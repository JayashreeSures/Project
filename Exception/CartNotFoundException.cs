namespace Cake_palace.Exceptions
{
    public class CartNotFoundException : ApplicationException
    {
        public CartNotFoundException(string msg) : base(msg) { }
        public CartNotFoundException()
        {
            
        }
    }
}
