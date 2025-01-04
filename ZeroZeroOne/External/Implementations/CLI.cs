using ZeroZeroOne.External.Interfaces;

namespace ZeroZeroOne.External.Implementations
{
    public class CLI : IUI
    {
        public (string email, string password) ReadCredentials()
        {
            while (true)
            {
                Console.WriteLine("ZeroOne Username: ");
                string? username = Console.ReadLine();

                Console.WriteLine();

                Console.WriteLine("ZeroOne Password: ");
                string? password = Console.ReadLine();

                if (!string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password)) return (username!, password!);

                Console.WriteLine("Try again");
            }
        }
    }
}
