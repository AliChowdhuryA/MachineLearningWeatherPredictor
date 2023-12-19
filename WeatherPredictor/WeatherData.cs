/*
    I want this web application to...
        Check the weather in a given city
        Display the weather in a user-friendly way
        Predict the weather for the next 5 days
        Allow the user to select a city
        Allow the user to select a date
        Allow the user to select a time
    
*/


 public class WeatherData
{
    public double ApparentTemperature { get; set; }
    public string CategoricalRain { get; set; }
    public string CategoricalSnow { get; set; }
    public double DewpointTemperature { get; set; }
    public double PotentialEvaporationRate { get; set; }
    public double PrecipitationRate { get; set; }
    public double Pressure { get; set; }
    public double RelativeHumidity { get; set; }
    public double SpecificHumidity { get; set; }
    public double Temperature { get; set; }
    public double TotalCloudCover { get; set; }
    public double UComponentOfWind { get; set; }
    public double VComponentOfWind { get; set; }
    public double Visibility { get; set; }
    public double WindSpeedGust { get; set; }
    public string City { get; set; } // The city for which the weather data is for
    public DateTime Date { get; set; } // The date for which the weather data is for
    public TimeSpan Time { get; set; } // The time for which the weather data is for
    public List<WeatherData> Forecast { get; set; } // The weather forecast for the next 5 days
}

