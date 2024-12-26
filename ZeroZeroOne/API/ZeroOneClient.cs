using ZeroZeroOne.Entities.ZeroOne;

namespace ZeroZeroOne.API;

public class ZeroOneClient
{
    private readonly string _baseUrl = "https://api.zeroone.la/api/vistas/5f5962bf-fbb5-4543-0ea4-08da32d06ff0";
    private readonly string _username;
    private readonly string _password;

    public ZeroOneClient(string username, string password)
    {
        _username = username;
        _password = password;
    }

    public async Task<string> Login()
    {
        throw new NotImplementedException();
    }

    public Options GetOptions()
    {
        throw new NotImplementedException();
    }
}

