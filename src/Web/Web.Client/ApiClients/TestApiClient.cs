namespace Web.Client.ApiClients;

public class TestApiClient(HttpClient httpClient)
{
    public async Task<string> GetData()
    {
        var response = await httpClient.GetStringAsync("");
        return response ?? "error!";
    }
}
