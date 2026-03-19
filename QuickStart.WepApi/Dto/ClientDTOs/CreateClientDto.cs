namespace QuickStart.WepApi.DTOs.ClientDTOs
{
    public class CreateClientDto
    {
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
