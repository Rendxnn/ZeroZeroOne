using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ZeroZeroOne.API.ZeroOne.Models;
using ZeroZeroOne.Utils;

namespace ZeroZeroOne.API.ZeroOne;



public class ZeroOneClient
{
    private readonly Uri _baseUrl;
    private readonly string _companyId;
    private readonly string _username;
    private readonly string _password;
    private readonly HttpClient _httpClient;

    public ZeroOneClient(string username, string password)
    {
        _baseUrl = new Uri("https://api.zeroone.la/api/");
        _companyId = ZeroOneConstants.EmasTCompanyId;
        _username = username;
        _password = password;
        _httpClient = new HttpClient();
    }

    private async Task Login()
    {
        Uri baseUrl = new(_baseUrl, "auth/login");

        ZeroOneModels.LoginRequest request = new() { Email = _username, Password = _password, CompanyId = _companyId };

        string serializedRequest = JsonSerializer.Serialize(request);

        StringContent requestContent = new(serializedRequest, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PostAsync(baseUrl, requestContent);

        string responseContent = await response.Content.ReadAsStringAsync();

        ZeroOneModels.LoginResponse loginResponse = JsonSerializer.Deserialize<ZeroOneModels.LoginResponse>(responseContent)
            ?? throw new Exception("Error while trying to log in");

        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {loginResponse.Token}");
    }

    public async Task<ListsResponse> GetOptions()
    {
        await Login();

        Uri url = new Uri(_baseUrl, $"vistas/{ZeroOneConstants.HoursRegistryViewId}/cargar-listas");

        HttpResponseMessage response = await _httpClient.PostAsync(url, new StringContent("{}", Encoding.UTF8, "application/json"));

        string responseContent = await response.Content.ReadAsStringAsync();

        ListsResponse lists = JsonSerializer.Deserialize<ListsResponse>(responseContent) ?? throw new Exception("Error while getting lists from ZeroOne");

        return lists;
    }
}

