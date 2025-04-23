using ZeroZeroOne.API.ZeroOne.Models;
using ZeroZeroOne.Entities;

namespace ZeroZeroOne.External.Interfaces
{
    public interface IUI
    {
        UserCredentials ReadCredentials();
        ProjectInformation ReadProjectInformation(ListsResponse options);
        void ShowError(string message);
    }
}
