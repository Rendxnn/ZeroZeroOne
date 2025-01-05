using ZeroZeroOne.SetUp;
using ZeroZeroOne.External.Implementations;
using ZeroZeroOne.Utils;

namespace ZeroZeroOne.App;
public class Program
{
    private static readonly CLI CLI = new();
    private static readonly SetUpManager setUpManager = new(CLI);

    public static async Task Main(string[] args)
    {
        foreach (string arg in args)
        {
            if (arg == CommandConstants.StartProjectCommand)
            {
                await setUpManager.SetUpProject();
            }
        }
    }
}