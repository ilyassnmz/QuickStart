namespace QuickStart.WebUI.Dtos.Testimonials
{
    public class UpdateTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public string ImageUrl { get; set; }
    }
}
