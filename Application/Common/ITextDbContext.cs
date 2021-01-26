
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common
{
    public interface ITextDbContext
    {
        DbSet<TextEntity> Texts { get; set; }

    }
}
