using catalogo_jogos.Entities;
using Microsoft.EntityFrameworkCore;

namespace catalogo_jogos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Game> Games  { get; set; }
    }
}