namespace QuickStart.WebApi.Dto
{
    public class CreateSliderDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}