namespace QuickStart.WepApi.DTOs.GalleryDTOs
{
    public class ResultGalleryDto
    {
        public int GalleryId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
