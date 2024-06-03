namespace HR.Application.Exceptions
{
    public class NotFoundEception : ApplicationException
    {
        public NotFoundEception(string name, object key) : base($"{name} ({key}) was not found")
        {

        }
    }
}
