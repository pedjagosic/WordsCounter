using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class TextDbContext : DbContext
    {
        private static readonly string SqlConnectionString =
            $"Server=(localdb)\\mssqllocaldb;Database=TextDb;Trusted_Connection=True;MultipleActiveResultSets=true;";

        public DbSet<TextEntity> Texts { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlConnectionString);
        }
    }
}
