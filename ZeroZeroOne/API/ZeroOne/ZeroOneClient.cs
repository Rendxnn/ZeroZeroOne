using System.Net.Mime;
using System.Text.Json;
using ZeroZeroOne.Entities.ZeroOne;

namespace ZeroZeroOne.API.ZeroOne;



public class ZeroOneClient
{
    private readonly string _baseUrl;
    private readonly string _companyId;
    private readonly string _username;
    private readonly string _password;
    private readonly HttpClient _httpClient;

    public ZeroOneClient(string username, string password)
    {
        _baseUrl = "https://api.zeroone.la/api/";
        _companyId = "24b6c5d5-5653-4a98-be3b-48eed320f4cd";
        _username = username;
        _password = password;
        _httpClient = new HttpClient();
    }

    private async Task<ZeroOneModels.LoginResponse> Login()
    {
        string baseUrl = Path.Combine("auth", "login");

        ZeroOneModels.LoginRequest request = new() { Email = _username, Password = _password, CompanyId = _companyId };

        StringContent requestContent = new(JsonSerializer.Serialize(request));

        HttpResponseMessage response = await _httpClient.PostAsync(baseUrl, requestContent);

        string responseContent = await response.Content.ReadAsStringAsync();

        ZeroOneModels.LoginResponse? loginResponse = JsonSerializer.Deserialize<ZeroOneModels.LoginResponse>(responseContent);

        return loginResponse ?? throw new Exception("Error while trying to log in");
    }

    public Options GetOptions()
    {
        throw new NotImplementedException();
    }
}

