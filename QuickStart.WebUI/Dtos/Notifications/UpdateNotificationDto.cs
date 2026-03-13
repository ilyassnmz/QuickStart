namespace QuickStart.WebUI.Dtos.Notifications
{
    public class UpdateNotificationDto
    {
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public int NotificationTypeId { get; set; }
    }
}
