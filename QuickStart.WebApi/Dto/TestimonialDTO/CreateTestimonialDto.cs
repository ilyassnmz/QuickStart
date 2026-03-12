namespace QuickStart.WebApi.Dto
{
    public class CreateTestimonialDto
    {
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Rate { get; set; }
    }
}