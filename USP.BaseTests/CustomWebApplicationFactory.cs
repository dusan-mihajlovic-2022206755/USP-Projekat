using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using MongoDB.Entities;

namespace USP.BaseTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    public CustomWebApplicationFactory()
    {
        Task.Run(async () =>
            {
                await DB.InitAsync("UspBazaZaTestiranje",
                    MongoClientSettings.FromConnectionString(
                        "mongodb+srv://dusanmihajlovic22:suEUu9EmTEJOQnqZ@cluster-usp.5picf.mongodb.net/?retryWrites=true&w=majority&appName=Cluster-usp"));
            })
            .GetAwaiter()
            .GetResult();
    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(IHostedService));
        });
    }
}