using Crypto.Application.CQRS.Handlers.Query;
using Crypto.Application.CQRS.Query;
using Crypto.Application.CQRS.Response;
using Crypto.Infrastructure.Store;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Crypto.Presentation.Api.SignalRHub.Crypto.Application.CQRS.Handlers.Query;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "CorsPolicy",
                policy =>
                {
                    policy.WithOrigins("http://localhost:63342")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials();
                });
        });

        builder.Services.AddControllers();
        builder.Services.AddSignalR();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<CryptoContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("CryptoConnection"));
        });

        var assembly = typeof(Crypto.Application.CQRS.Handlers.BaseHandler).Assembly;
        builder.Services.AddMediatR(config => { config.RegisterServicesFromAssemblies(Assembly.Load("Crypto.Application.CQRS")); });
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

            // Add SignalR support to Swagger
            c.AddSignalRSwaggerGen();

            // Other Swagger configuration...
        });
        var app = builder.Build();

        // Apply CORS before routing and SignalR hub mapping
        app.UseCors("CorsPolicy");

        app.MapHub<Orders>("/orders/SendGuidsToClients");
        

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
                // Other Swagger UI configuration...
            });

        }

        app.UseAuthorization();
        app.UseRouting();

        app.MapControllers();

        app.Run();
    }
}
