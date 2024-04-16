namespace Cake_palace.Exceptions
{
    public class NoItemsInCartException : ApplicationException
    {
        public NoItemsInCartException(string msg) : base(msg)
        {
            
        }
        public NoItemsInCartException()
        {
            
        }
    }
}
