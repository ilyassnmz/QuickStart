namespace QuickStart.WebApiLayer.DTOs.AboutDTOs
{
    public class CreateAboutDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
    }
}
