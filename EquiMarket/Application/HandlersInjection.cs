using Application.UseCases.Producer.Products.Commands.Delete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class HandlersInjection
{
    public static IServiceCollection RegisterApplicationHandlers(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }

}
