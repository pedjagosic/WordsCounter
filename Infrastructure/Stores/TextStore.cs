using Application.Stores;
using Application.Text.Queries;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Stores
{
    public class TextStore : ITextStore
    {
        private readonly TextDbContext _context;

        public TextStore(TextDbContext context)
        {
            _context = context;
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
