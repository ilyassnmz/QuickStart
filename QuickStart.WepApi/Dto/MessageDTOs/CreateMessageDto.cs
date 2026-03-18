namespace QuickStart.WepApi.DTOs.MessageDTOs
{
    public class CreateMessageDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
        public int NotificationTypeId { get; set; }
    }
}