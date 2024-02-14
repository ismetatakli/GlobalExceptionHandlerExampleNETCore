namespace GlobalExceptionHandlerExample
{
    public class ClientException:Exception
    {
        public ClientException(string message) : base(message)
        {
            
        }
    }
}
