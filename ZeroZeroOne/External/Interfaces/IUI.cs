namespace ZeroZeroOne.External.Interfaces
{
    public interface IUI
    {
        (string email, string password) ReadCredentials(); 
    }
}
