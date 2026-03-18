namespace QuickStart.WepApi.DTOs.TestimonialDTOs
{
    public class UpdateTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public int Rate { get; set; }
    }
}