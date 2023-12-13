
using System.Net.Http.Json;
using System.Text.Json;

public class LocalityApiService : ILocalityService
{
    private readonly HttpClient _client;

    public LocalityApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<LocalityResponse?> PostCreateLocality(CreateLocalityRequest? request)
    {
        var responseMessage = await _client.PostAsJsonAsync("/api/v1/localities", request);

      var content = await responseMessage.Content.ReadAsStringAsync();

      return JsonSerializer.Deserialize<LocalityResponse>(content);
    }
}

public class LocalityDto : Response
{
}

public class CreateLocalityDto : Request
{
}