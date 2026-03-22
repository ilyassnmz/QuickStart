namespace QuickStart.WebApiLayer.DTOs.AboutDTOs
{
    public class ResultAboutDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
    }
}
