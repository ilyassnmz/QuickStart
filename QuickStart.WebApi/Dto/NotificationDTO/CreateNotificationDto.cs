namespace QuickStart.WebApi.Dto.NotificationDto
{
    public class CreateNotificationDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public int NotificationTypeId { get; set; }
    }
}