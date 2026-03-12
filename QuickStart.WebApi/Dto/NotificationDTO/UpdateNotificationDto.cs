namespace QuickStart.WebApi.Dto.NotificationDto
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