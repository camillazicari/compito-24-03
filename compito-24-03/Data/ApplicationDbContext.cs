using Microsoft.EntityFrameworkCore;
using compito_24_03.Models;

namespace compito_24_03.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<Student> Students { get; set; }
    }
}
