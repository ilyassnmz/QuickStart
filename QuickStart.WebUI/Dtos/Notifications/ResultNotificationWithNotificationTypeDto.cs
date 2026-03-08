namespace QuickStart.WebUI.Dtos.Notifications
{
    public class ResultNotificationWithNotificationTypeDto
    {
        public int notificationId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string isRead { get; set; }
        public string notificationTypeName { get; set; }
    }
}