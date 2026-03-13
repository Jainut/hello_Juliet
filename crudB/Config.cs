using Microsoft.Extensions.Configuration;

public class Config
{
    public static string URL { get; }

    static Config()
    {
        var config = new ConfigurationBuilder()
       .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
       .AddJsonFile("appsettingsDevelopment.json", optional: false, reloadOnChange: true)
       .Build();

        URL = config["ApiSettings:BaseUrl"];
    }
}