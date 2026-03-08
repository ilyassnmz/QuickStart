namespace QuickStart.WebApi.Entity
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public string IsRead { get; set; }
        public int NotificationTypeId { get; set; }

        public NotificationType NotificationType { get; set; }

    }
}
