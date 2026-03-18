using Microsoft.EntityFrameworkCore;
using QuickStart.WepApi.Entity;

namespace QuickStart.WepApi.Context
{
    public class QuickStartContext:DbContext
    {
        //sql bağlantı adresimiz tutar.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; initial catalog=DbQuickStartAkademiq; integrated security=true ; TrustServerCertificate=True");
        }

        public DbSet<Service> Services { get; set; }

        public DbSet<Testimonial> Testimonials { get; set;}

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<NotificationType> NotificationTypes { get; set; }
    }
}
