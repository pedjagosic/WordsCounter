using System.Collections.Generic;
using Application.Text.Queries;
using Domain.Entities;
using System.Threading.Tasks;
using Application.Dto;

namespace Application.Stores
{
    public interface ITextStore
    {
        Task<IEnumerable<TextDto>> GetAllAsync();
        Task<int> AddAsync(TextEntity textEntity);
        Task<TextEntity> FindByIdAsync(GetTextQuery query);
        Task DeleteAllAsync();
    }
}
