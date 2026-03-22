namespace QuickStart.WebApiLayer.DTOs.AboutDTOs
{
    public class UpdateAboutDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
    }
}
