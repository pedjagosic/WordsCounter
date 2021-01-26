using System.Collections.Generic;
using Application.Dto;
using Application.Text.Commands;
using Application.Text.Queries;
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

            serviceCollection
                .AddScoped<IRequestHandler<GetAllTextsQuery, IEnumerable<TextDto>>, GetAllTextsQuery.GetAllTextsQueryHandler>();

            return serviceCollection;
        }
    }
}
