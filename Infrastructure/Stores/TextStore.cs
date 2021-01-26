using System.Collections.Generic;
using Application.Stores;
using Application.Text.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Application.Dto;
using Shared.Abstractions;

namespace Infrastructure.Stores
{
    public class TextStore : ITextStore
    {
        private readonly TextDbContext _context;
        private readonly ITypeConverter<TextEntity, TextDto> _textEntityToTextDtoConverter;

        public TextStore(TextDbContext context, ITypeConverter<TextEntity, TextDto> textEntityToTextDtoConverter)
        {
            _context = context;
            _textEntityToTextDtoConverter = textEntityToTextDtoConverter;
        }

        public async Task<IEnumerable<TextDto>> GetAllAsync()
        {
            var textsDtos = new List<TextDto>();
            var texts = await _context.Texts.ToListAsync();
            foreach (var text in texts)
            {
                textsDtos.Add(_textEntityToTextDtoConverter.Convert(text));
            }
            return textsDtos;
        }

        public async Task<int> AddAsync(TextEntity textEntity)
        {
            await _context.Texts.AddAsync(textEntity);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task DeleteAllAsync()
        {
            var texts = await _context.Texts.ToArrayAsync();
            _context.Texts.RemoveRange(texts);
            await _context.SaveChangesAsync();
        }

        public async Task<TextEntity> FindByIdAsync(GetTextQuery query)
            => await _context.Texts.FirstOrDefaultAsync(x => x.Id == query.Id);
    }
}
