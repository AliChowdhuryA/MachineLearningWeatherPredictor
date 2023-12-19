using System.Net;
using Moq;
using Moq.Protected;
using Xunit;

public class WeatherServiceTests
{
    [Fact]
    public async Task FetchWeatherDataAsync_ReturnsWeatherData()
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{ \"temperature\": 20 }"), // Mock response
            });

        var client = new HttpClient(mockHttpMessageHandler.Object);
        var weatherService = new WeatherService(client);

        // Act
        var weatherData = await weatherService.FetchWeatherDataAsync();

        // Assert
        Assert.NotNull(weatherData);
        Assert.Equal(20, weatherData.Temperature);
    }
}