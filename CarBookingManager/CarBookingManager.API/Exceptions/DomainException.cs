namespace CarBookingManager.API.Exceptions
{
    public abstract class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }

    public class DomainNotFoundException : DomainException
    {
        public DomainNotFoundException(string message):base(message)
        {

        }
    }

    public class DomainAlreadyExistException:DomainException
    {
        public DomainAlreadyExistException(string message) : base(message)
        {
             
        }
    }
          
}
