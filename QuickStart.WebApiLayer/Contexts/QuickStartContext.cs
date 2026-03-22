using Microsoft.EntityFrameworkCore;
using QuickStart.WebApiLayer.Entities;

namespace QuickStart.WebApiLayer.Contexts
{
    public class QuickStartContext : DbContext
    {
        public QuickStartContext(DbContextOptions<QuickStartContext> options) : base(options)
        {
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FAQ> Faqs { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FeaturedService> FeaturedServices { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
