using Common;
using System.Text.Json;

namespace ConsoleApp
{
    internal class UnitTestApiClient : IUnitTestsApiClient
    {
        private readonly HttpClient httpClient;
        private readonly string baseUrl;

        public UnitTestApiClient(HttpClient httpClient, string baseUrl)
        {
            this.httpClient = httpClient;
            this.baseUrl = baseUrl;
        }
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForcasts()
        {
            var response = await httpClient.GetAsync($"{baseUrl}/WeatherForecast");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

          return JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(result); 
        }
    }
}
