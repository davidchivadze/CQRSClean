using Crypto.Infrastructure.Store;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Crypto.Presentation.Api.SignalRHub.Crypto.Application.CQRS.Handlers.Query;
using Crypto.Domain.Repository.UnitOfWork;
using Crypto.Infrastructure.Repository.UnitOfWork;
using AutoMapper;
using Crypto.Presentation.Api.ApiHelpers.ActionFilter.Validation;
using Crypto.Presentation.Api.ApiHelpers.Middlewares;
using Crypto.Presentation.Api.ApiHelpers.Mapper;
using Crypto.Presentation.Api.Worker;

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
                    policy.WithOrigins("http://localhost:63343")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials();
                });
        });

        builder.Services.AddControllers(opt =>
        {
            opt.Filters.Add<ValidationActionFilter>();
        });
        builder.Services.AddSignalR();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<CryptoContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("CryptoConnection"));
        });


        builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

        var assembly = typeof(Crypto.Application.CQRS.Handlers.BaseHandler).Assembly;
        builder.Services.AddMediatR(config => { config.RegisterServicesFromAssemblies(Assembly.Load("Crypto.Application.CQRS")); });
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });


            c.AddSignalRSwaggerGen();
        });

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfiles());
        });

        IMapper mapper = mappingConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
       // builder.Services.AddHostedService<OrderManager>();
        var app = builder.Build();
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseCors("CorsPolicy");

        app.MapHub<Orders>("/orders/GetOrder");

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
