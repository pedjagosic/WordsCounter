using System.Collections.Generic;
using Application.Dto;
using Application.Stores;
using Application.Text.Queries;
using Domain.Entities;
using Infrastructure.Stores;
using Infrastructure.TypeConverters;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Abstractions;

namespace WebApi.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITextStore, TextStore>();
            serviceCollection
                .AddTransient<ITypeConverter<TextEntity, TextDto>,TextEntityToTextDtoConverter>();
            serviceCollection
                .AddScoped<IRequestHandler<GetAllTextsQuery,IEnumerable<TextDto>>,
                    GetAllTextsQuery.GetAllTextsQueryHandler>();
            return serviceCollection;
        }
    }
}