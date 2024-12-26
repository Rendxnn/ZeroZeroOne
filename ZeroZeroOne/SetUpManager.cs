using ZeroZeroOne.Utils;

namespace ZeroZeroOne
{
    public class SetUpManager
    {
        public void SetUpProject()
        {
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), FileConstants.PostCommitTemplatePath);
            string templateContent = File.ReadAllText(templatePath);


        }
    }
}
