namespace SaaSFileManager.Application.Exceptions
{
    public class AccountNotActivatedException : Exception
    {
        public AccountNotActivatedException(string message) : base(message)
        {
        }
    }
}
