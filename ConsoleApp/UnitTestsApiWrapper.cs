using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class UnitTestsApiWrapper
    {
        private readonly IUnitTestsApiClient unitTestsApi;


        public UnitTestsApiWrapper(IUnitTestsApiClient unitTestsApi)
        {
            this.unitTestsApi = unitTestsApi;

        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
        {
            var response = await unitTestsApi.GetWeatherForcasts();
            if (response is null || !response.Any()) throw new Exception("Response is empty or null");

            return response;

        }
    }
}
