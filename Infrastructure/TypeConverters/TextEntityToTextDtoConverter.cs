using Application.Dto;
using Domain.Entities;
using Shared.Abstractions;

namespace Infrastructure.TypeConverters
{
    public class TextEntityToTextDtoConverter : ITypeConverter<TextEntity, TextDto>
    {
        public TextDto Convert(TextEntity source)
            => new TextDto(source.Id, source.Text);
    }
}