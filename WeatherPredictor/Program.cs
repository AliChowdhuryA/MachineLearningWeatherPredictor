using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();


// Initialize the HttpClient object
var client = new HttpClient();

try
{
    // Send a GET request to the weather API
    var response = await client.GetAsync("https://api.blueskyapi.io");

    // Ensure the request was successful
    response.EnsureSuccessStatusCode();

    // Read the response body as a string
    var responseBody = await response.Content.ReadAsStringAsync();

    // Deserialize the response body into a WeatherData object
    var weatherData = JsonSerializer.Deserialize<WeatherData>(responseBody);
}
catch (HttpRequestException e)
{
    Console.WriteLine("\nException Caught!");
    Console.WriteLine("Message :{0} ", e.Message);
}
catch (JsonException e)
{
    Console.WriteLine("\nException Caught!");
    Console.WriteLine("Message :{0} ", e.Message);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
