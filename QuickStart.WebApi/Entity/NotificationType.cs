namespace QuickStart.WebApi.Entity
{
    public class NotificationType
    {
        public int NotificationTypeId { get; set; }

        public string Name { get; set; }
        
        public List<Notification> Notifications { get; set; }
    }
}
