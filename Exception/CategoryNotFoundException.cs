namespace Cake_palace.Exceptions
{
    public class CategoryNotFoundException : ApplicationException
    {
        public CategoryNotFoundException(string msg) :base(msg) { }
        public CategoryNotFoundException()
        {
            
        }
    }
}
