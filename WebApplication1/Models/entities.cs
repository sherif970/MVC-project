using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class entities:IdentityDbContext<applicationuser>
    {
        public entities() : base()
        {

        }
        public entities(DbContextOptions options):base(options) 
        {
        }
        public DbSet<employe> employes { get; set; }
        public DbSet<department> departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=master;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
