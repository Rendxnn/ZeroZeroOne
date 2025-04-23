using ZeroZeroOne.API.ZeroOne.Models;

namespace ZeroZeroOne.Entities
{
    public class ProjectInformation
    {
        public Client Client { get; set; } = null!;
        public Project Project { get; set; } = null!;
        public Activity Activity { get; set; } = null!;
    }
}
