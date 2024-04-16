namespace Cake_palace.Exceptions
{
    public class InvalidCredentialsException : ApplicationException
    {
        public InvalidCredentialsException(string msg) : base(msg) { }
        public InvalidCredentialsException()
        {
            
        }

    }
}