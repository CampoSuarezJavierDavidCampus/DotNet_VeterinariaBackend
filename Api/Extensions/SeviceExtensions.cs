using Core.Interfaces;
using Infrastructure.Repositories;

namespace Api.Extensions;
public static class SeviceExtensions{
    public static void AddApiServices(this IServiceCollection services){
        services.AddSingleton<IUnitOfWork,UnitOfWork>();
    }
    
}
