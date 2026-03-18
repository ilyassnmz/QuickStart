using QuickStart.WepApi.Entities;

namespace QuickStart.WepApi.Entity
{
    public class NotificationType
    {
        public int NotificationTypeId { get; set; }
        public string Name { get; set; }

        public List<Notification> Notifications { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
