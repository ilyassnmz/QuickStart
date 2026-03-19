namespace QuickStart.WebUI.Models
{
    public class ResultSubscribeDto
    {
        public int SubscribeId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
