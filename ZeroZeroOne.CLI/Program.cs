using ZeroZeroOne.SetUp;
using ZeroZeroOne.External.Implementations;
using ZeroZeroOne.Utils;

namespace ZeroZeroOne.App;
public class Program
{
    private static readonly CLI CLI = new();
    private static readonly SetUpManager setUpManager = new(CLI);

    public static void Main(string[] args)
    {
        foreach (string arg in args)
        {
            if (arg == CommandConstants.StartProjectCommand)
            {
                setUpManager.SetUpProject();
            }
        }
    }
}