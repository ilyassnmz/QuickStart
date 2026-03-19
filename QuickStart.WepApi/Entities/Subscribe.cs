namespace QuickStart.WepApi.Entities
{
    public class Subscribe
    {
        public int SubscribeId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
}
