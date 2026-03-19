namespace QuickStart.WepApi.Entities
{
    public class Chef
    {
        public int ChefId { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string TwitterUrl { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
