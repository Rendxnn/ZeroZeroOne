using ZeroZeroOne.API.ZeroOne;
using ZeroZeroOne.External.Interfaces;
using ZeroZeroOne.Utils;

namespace ZeroZeroOne.SetUp
{
    public class SetUpManager
    {
        private readonly ZeroOneClient zeroOneClient;
        private readonly string email;
        private readonly string password;
        private readonly IUI _UI;

        public SetUpManager(IUI UI)
        {
            _UI = UI;
            (email, password) = _UI.ReadCredentials();
            zeroOneClient = new ZeroOneClient(email, password);
        }
        public void SetUpProject()
        {
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), FileConstants.PostCommitTemplatePath);
            string templateContent = File.ReadAllText(templatePath);

        }
    }
}
