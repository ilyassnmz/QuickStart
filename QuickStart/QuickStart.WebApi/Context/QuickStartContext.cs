using Microsoft.EntityFrameworkCore;
using QuickStart.WebApi.Entity;

namespace QuickStart.WebApi.Context
{
    public class QuickStartContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Ilyas; initial Catalog=DbQuickStartAkademiq; integrated security=true; TrustServerCertificate=True");
        }

        public DbSet<Service> Services { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }

    }
}
