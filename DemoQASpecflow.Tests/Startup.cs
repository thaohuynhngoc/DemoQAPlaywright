using DemoQAFramework.Config;
using DemoQAFramework.Driver;
using DemoQASpecflow.Tests.Pages;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;

namespace DemoQASpecflow.Tests;

public class Startup
{
    [ScenarioDependencies]
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton(ConfigReader.ReadConfig())
                .AddScoped<IPlaywrightDriver, PlaywrightDriver>()
                .AddScoped<IPlaywrightDriverInitializer, PlaywrightDriverInitializer>()
                .AddScoped<IBookStorePage, BookStorePage>()
                .AddScoped<ILoginPage, LoginPage>();
            
            return services;
        }
}