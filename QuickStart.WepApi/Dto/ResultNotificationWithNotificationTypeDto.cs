namespace QuickStart.WepApi.Dto
{
    public class ResultNotificationWithNotificationTypeDto
    {
        public int NotificationId { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public bool IsRead { get; set; }

        public string NotificationTypeName { get; set; }
    }
}
