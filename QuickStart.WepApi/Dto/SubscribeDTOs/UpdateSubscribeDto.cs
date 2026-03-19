namespace QuickStart.WepApi.DTOs.SubscribeDTOs
{
    public class UpdateSubscribeDto
    {
        public int SubscribeId { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
