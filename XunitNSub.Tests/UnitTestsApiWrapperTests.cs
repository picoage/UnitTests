using Common;
using ConsoleApp;
using NSubstitute;
using Xunit;

namespace XunitNSub.Tests
{
    public class UnitTestsApiWrapperTests
    {
        [Fact]
        public async Task Should_Return_Valid_Response()
        {
            //Arrange 
            IUnitTestsApiClient unitTestsApi = Substitute.For<IUnitTestsApiClient>();
            IList<WeatherForecast> weatherForecasts = new List<WeatherForecast> { new WeatherForecast { Date = DateTime.Now, Summary = "TestSum", TemperatureC = 35 } };
            unitTestsApi.GetWeatherForcasts().Returns(weatherForecasts);
            UnitTestsApiWrapper unitTestsApiWrapper = new(unitTestsApi);

            //Act
            var result = await unitTestsApiWrapper.GetWeatherForecasts();

            //Assert
            await unitTestsApi.Received(1).GetWeatherForcasts();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task Should_Throw_Error_When_Response_Is_Empty()
        {
            //Arrange 
            IUnitTestsApiClient unitTestsApi = Substitute.For<IUnitTestsApiClient>();
            unitTestsApi.GetWeatherForcasts().Returns(new List<WeatherForecast>());
            UnitTestsApiWrapper unitTestsApiWrapper = new(unitTestsApi);

            try
            {
                //Act
                var result = await unitTestsApiWrapper.GetWeatherForecasts();
            }
            catch (Exception ex)
            {
                await unitTestsApi.Received(1).GetWeatherForcasts();
                Assert.Equal("Response is empty or null", ex.Message);
            }

        }

        [Fact]
        public async Task Should_Not_Return_Any_Values_When_UnitTestApiClient_Return_Error()
        {
            //Arrange 
            IUnitTestsApiClient unitTestsApi = Substitute.For<IUnitTestsApiClient>();
            UnitTestsApiWrapper unitTestsApiWrapper = new(unitTestsApi);

            //Force to throw
            unitTestsApi.GetWeatherForcasts().Returns(Task.FromException<IEnumerable<WeatherForecast>>(new Exception("Service called failed")));


            // Act and Assert
            await Assert.ThrowsAsync<Exception>(async () => await unitTestsApi.GetWeatherForcasts()); //Checking id exception is thrown


        }
    }
}