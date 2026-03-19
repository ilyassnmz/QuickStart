namespace QuickStart.WebUI.Dtos.Gallery
{
    public class CreateGalleryDto
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
