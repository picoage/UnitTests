// See https://aka.ms/new-console-template for more information
using ConsoleApp;




IUnitTestsApiClient unitTestsApiClient = new UnitTestApiClient(new HttpClient(), "https://localhost:7291"); 
UnitTestsApiWrapper unitTestsApiWrapper = new UnitTestsApiWrapper(unitTestsApiClient);

var results =await unitTestsApiWrapper.GetWeatherForecasts();

Console.WriteLine(results.First().Summary); 

