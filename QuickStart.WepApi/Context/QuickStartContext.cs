using Microsoft.EntityFrameworkCore;
using QuickStart.WepApi.Entities;
using QuickStart.WepApi.Entity;

namespace QuickStart.WepApi.Context
{
    public class QuickStartContext : DbContext
    {
        public QuickStartContext(DbContextOptions<QuickStartContext> options) : base(options)
        {
        }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationType> NotificationTypes { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}