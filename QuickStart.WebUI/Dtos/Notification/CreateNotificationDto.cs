namespace QuickStart.WebUI.Dtos.Notification
{
    public class CreateNotificationDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int NotificationTypeId { get; set; }
    }
}
