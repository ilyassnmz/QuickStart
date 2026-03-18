namespace QuickStart.WepApi.DTOs.NotificationDTOs
{
    public class CreateNotificationDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public int NotificationTypeId { get; set; }
    }
}