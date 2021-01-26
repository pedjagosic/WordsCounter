using Application.Common;
using Application.Stores;
using Application.Text.Commands;
using Application.Text.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IRequestHandler<GetTextQuery, int>, GetTextQuery.GetTextQueryHandler>(); 
            
            serviceCollection
                .AddScoped<IRequestHandler<AddTextCommand, int>, AddTextCommand.AddTextCommandHandler>();

            return serviceCollection;
        }
    }
}
