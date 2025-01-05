using ZeroZeroOne.API.ZeroOne;
using ZeroZeroOne.API.ZeroOne.Models;
using ZeroZeroOne.External.Interfaces;
using ZeroZeroOne.Utils;

namespace ZeroZeroOne.SetUp
{
    public class SetUpManager
    {
        private readonly IUI _UI;
        private readonly ZeroOneClient zeroOneClient;
        private readonly string email;
        private readonly string password;

        public SetUpManager(IUI UI)
        {
            _UI = UI;
            (email, password) = _UI.ReadCredentials();
            zeroOneClient = new ZeroOneClient(email, password);
        }
        public async Task SetUpProject()
        {
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), FileConstants.PostCommitTemplatePath);
            string templateContent = File.ReadAllText(templatePath);

            ListsResponse options = await zeroOneClient.GetOptions();


            templateContent = ReplaceOnTemplate(templateContent);
        }

        private string ReplaceOnTemplate(string template)
        {
            template = template
                .Replace("{{ZeroOneUser}}", email)
                .Replace("{{ZeroOnePassword}}", password)
                .Replace("{{CompanyId}}", ZeroOneConstants.EmasTCompanyId);


            return template;
        }
    }
}
