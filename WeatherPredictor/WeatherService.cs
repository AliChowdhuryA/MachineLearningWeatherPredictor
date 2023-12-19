using System.Text.Json;

public class WeatherService
{
    // This variable will be used to make HTTP requests
    private readonly HttpClient _client;

    // This constructor will be used to inject the HttpClient object
    public WeatherService(HttpClient client)
    {
        _client = client;
    }

    // This method will be used to fetch weather data from the API
    public async Task<WeatherData?> FetchWeatherDataAsync()
    {
        try
        {
            // send Get Request to the weather API
            var response = await _client.GetAsync("https://api.blueskyapi.io");

            //Ensure request is successful
            response.EnsureSuccessStatusCode();

            //Read the response body as a string
            var responseBody = await response.Content.ReadAsStringAsync();

            // Deserialize the response body into a WeatherData object
            var weatherData = JsonSerializer.Deserialize<WeatherData>(responseBody);

            return weatherData;
        }
        catch(HttpRequestException e)
        {
            // Handle the exception
            Console.WriteLine("\nException Caught!");
            // Print the exception message
            Console.WriteLine("Message :{0} ", e.Message);
            return null;
        }
        catch(JsonException e)
        {
            // Handle the exception
            Console.WriteLine("\nException Caught!");
            // Print the exception message
            Console.WriteLine("Message :{0} ", e.Message);
            return null;
        }
    }
}