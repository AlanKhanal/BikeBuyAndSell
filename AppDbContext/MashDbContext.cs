using MashWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace MashWebApplication.AppDbContext
{
    public class MashDbContext:DbContext
    {
        public MashDbContext(DbContextOptions<MashDbContext> options):
            base(options)
        {

        }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }

    }
}
