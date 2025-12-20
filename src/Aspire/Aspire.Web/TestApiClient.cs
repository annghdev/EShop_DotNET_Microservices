namespace Aspire.Web;

public class TestApiClient(HttpClient httpClient)
{
    public async Task<string> GetDataAsync(CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync("/", cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync(cancellationToken);
    }
}
