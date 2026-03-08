namespace QuickStart.WebApi.Dto
{
    public class ResultNotificationWithNotificationTypeDto
    {
        public int NotificationId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public string IsRead { get; set; }
        public string NotificationTypeName { get; set; }
    }
}
