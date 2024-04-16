using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Cake_palace.Exceptions
{
    public class ProductNotFoundException : ApplicationException
    {
        public ProductNotFoundException(string msg) : base(msg)
        {
            
        }
        public ProductNotFoundException()
        {
            
        }
    }
}
