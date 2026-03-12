namespace QuickStart.WebApi.Dto
{
    public class UpdateSliderDto
    {
        public int SliderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
    }
}