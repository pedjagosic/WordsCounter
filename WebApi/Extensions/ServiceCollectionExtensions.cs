using Application.Common;
using Application.Stores;
using Infrastructure.Persistence;
using Infrastructure.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITextStore, TextStore>();
            serviceCollection.AddScoped<ITextDbContext, TextDbContext>();
            return serviceCollection;
        }
    }
}