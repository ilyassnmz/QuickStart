namespace QuickStart.WebUI.Dtos.Slider
{
    public class UpdateSliderDto
    {
        public int SliderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagesUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
