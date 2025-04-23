using ZeroZeroOne.API.ZeroOne.Models;
using ZeroZeroOne.Entities;
using ZeroZeroOne.External.Interfaces;

namespace ZeroZeroOne.External.Implementations
{
    public class CLI : IUI
    {
        public UserCredentials ReadCredentials()
        {
            while (true)
            {
                Console.Write("ZeroOne Username: ");
                string? username = Console.ReadLine();

                Console.WriteLine();

                Console.Write("ZeroOne Password: ");
                string password = ReadPassword(); 

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    return new UserCredentials { Username = username,  Password = password };

                Console.WriteLine("\nTry again\n");
            }
        }

        public ProjectInformation ReadProjectInformation(ListsResponse options)
        {
            while (true)
            {
                List<Client> clients = options.Clients;
                Console.WriteLine("Seleccione un cliente: (Ingrese solo el número)");
                for (int index = 0; index < clients.Count; index++) Console.WriteLine($"{index + 1}. {clients[index].Name}");
                if (!int.TryParse(Console.ReadLine(), out int clientIndex)) continue;
                Client client = clients[clientIndex - 1];

                List<Project> projects = options.Projects.Where(p => p.ClientId == client.ClientId).ToList();
                Console.WriteLine("Seleccione un proyecto: (Ingrese solo el número)");
                for (int index = 0; index < projects.Count; index++) Console.WriteLine($"{index + 1}. {projects[index].Name}");
                if (!int.TryParse(Console.ReadLine(), out int  projectIndex)) continue;
                Project project = projects[projectIndex - 1];

                List<Activity> activities = options.Activities;
                Console.WriteLine("Seleccione una actividad: (Ingrese solo el número)");
                for (int index = 0; index < activities.Count; index++) Console.WriteLine($"{index + 1}. {activities[index].Name}");
                if (!int.TryParse (Console.ReadLine(), out int activityIndex)) continue;    
                Activity activity = activities[activityIndex - 1];

                return new ProjectInformation { Activity =  activity, Project = project, Client = client };
            }
        }

        private string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true); 

                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[..^1]; 
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    Console.Write("*");
                    password += key.KeyChar;
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine(); 
            return password;
        }
    }
}
