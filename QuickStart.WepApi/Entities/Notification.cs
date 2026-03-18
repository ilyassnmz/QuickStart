namespace QuickStart.WepApi.Entity
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int NotificationTypeId { get; set; }

        public NotificationType NotificationType { get; set; }

    }
}
