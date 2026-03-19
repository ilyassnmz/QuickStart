namespace QuickStart.WepApi.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
