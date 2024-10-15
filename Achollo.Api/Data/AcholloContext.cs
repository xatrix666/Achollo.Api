using Achollo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Achollo.Api.Data
{
    public class AcholloContext : DbContext
    {
        public AcholloContext(DbContextOptions<AcholloContext> options) : base(options) { }

        public DbSet<Chollo> Chollos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
