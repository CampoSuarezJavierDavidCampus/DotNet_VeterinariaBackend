using System.Net;
using AspNetCoreRateLimit;
using Core.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Api.Extensions;
public static class SeviceExtensions{
    public static void AddApiServices(this IServiceCollection services){
        services.AddSingleton<IUnitOfWork,UnitOfWork>();
    }

    public static void ConfigureCors(this IServiceCollection services){
        services.AddCors(opts =>{
            opts.AddPolicy("CorsPolicy", policy =>{
                policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
    
    public static void ConfigureRateLimiting(this IServiceCollection services){
        services.AddMemoryCache();
        services.AddSingleton<IRateLimitConfiguration,RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();
        services.Configure<IpRateLimitOptions>(opts => {
            opts.EnableEndpointRateLimiting = true;
            opts.StackBlockedRequests = false;
            opts.HttpStatusCode = 429;
            opts.RealIpHeader = "X-Real-IP";
            opts.GeneralRules = new(){
                new(){
                    Endpoint = "*",
                    Period = "10s",
                    Limit = 2
                }
            };
        });
    }

    public static void ConfigureVersioning(this IServiceCollection services){
        services.AddApiVersioning(opts => {
            opts.DefaultApiVersion = new(1,0);
            opts.AssumeDefaultVersionWhenUnspecified = true;
            opts.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader("ver"),
                new HeaderApiVersionReader("X-Version")
            );
            opts.ReportApiVersions = true;
        });
    }
}
