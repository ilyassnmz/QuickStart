using Microsoft.EntityFrameworkCore;
using QuickStart.WebApi.Entity;

namespace QuickStart.WebApi.Context
{
    public class QuickStartContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Ilyas; initial Catalog=DbQuickStartAkademiq; integrated security=true; TrustServerCertificate=True");
        }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
    }
}