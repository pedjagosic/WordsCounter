using Application.Text.Queries;
using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Stores
{
    public interface ITextStore
    {
        Task<int> AddAsync(TextEntity textEntity);
        Task<TextEntity> FindByIdAsync(GetTextQuery query);
        Task DeleteAllAsync();
    }
}
