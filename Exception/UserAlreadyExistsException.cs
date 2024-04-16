namespace Cake_palace.Exceptions
{
    public class UserAlreadyExistsException : ApplicationException
    {
        public UserAlreadyExistsException(string msg) : base(msg) { }
        public UserAlreadyExistsException()
        {
            
        }
    }
}
