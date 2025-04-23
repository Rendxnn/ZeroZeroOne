using ZeroZeroOne.API.ZeroOne;
using ZeroZeroOne.API.ZeroOne.Models;
using ZeroZeroOne.Entities;
using ZeroZeroOne.External.Interfaces;
using ZeroZeroOne.Utils;

namespace ZeroZeroOne.SetUp
{
    public class SetUpManager
    {
        private readonly IUI _UI;
        private readonly UserCredentials _userCredentials;
        private readonly ProjectInformation _projectInformation = new();
        private readonly ZeroOneClient zeroOneClient;

        public SetUpManager(IUI UI)
        {
            _UI = UI;
            _userCredentials = _UI.ReadCredentials();
            zeroOneClient = new ZeroOneClient(_userCredentials.Username, _userCredentials.Password);

        }

        public async Task SetUpProject()
        {
            string basePath;

            #if DEBUG
                basePath = @"C:\Users\samir\source\repos\ZeroZeroOne";
            #else
                basePath = Directory.GetCurrentDirectory();
            #endif

            string postCommitPath = Path.Combine(basePath, FileConstants.PostCommitPath);
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), FileConstants.PostCommitTemplatePath);
            string templateContent = File.ReadAllText(templatePath);

            ListsResponse options = await zeroOneClient.GetOptions();

            ProjectInformation projectInformation = _UI.ReadProjectInformation(options);

            string replacedContent = ReplaceOnTemplate(templateContent, _userCredentials, projectInformation);


            File.WriteAllText(postCommitPath, replacedContent);

            return;
        }

        private static string ReplaceOnTemplate(string template, UserCredentials userCredentials, ProjectInformation projectInformation)
        {
            template = template
                .Replace("{{ZeroOneUser}}", userCredentials.Username)
                .Replace("{{ZeroOnePassword}}", userCredentials.Password)
                .Replace("{{CompanyId}}", ZeroOneConstants.EmasTCompanyId)
                .Replace("{{ProjectId}}", projectInformation.Project.ProjectId)
                .Replace("{{ActivityId}}", projectInformation.Activity.ActivityId)
                .Replace("{{ClientId}}", projectInformation.Client.ClientId)
                .Replace("{{Date}}", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));


            return template;
        }
    }
}
