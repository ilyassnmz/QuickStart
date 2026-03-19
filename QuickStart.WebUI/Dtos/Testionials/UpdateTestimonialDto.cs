namespace QuickStart.WebUI.Dtos.Testionials
{
    public class UpdateTestimonialDto
    {
        public int testimonialId { get; set; }
        public string fullName { get; set; }
        public string title { get; set; }
        public string descriptions { get; set; }
        public int rate { get; set; }
        public string imageUrl { get; set; }
    }
}
