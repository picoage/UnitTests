using Common;

namespace ConsoleApp
{
    public interface IUnitTestsApiClient
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForcasts();
    }
}
