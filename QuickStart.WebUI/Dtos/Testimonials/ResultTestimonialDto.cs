namespace QuickStart.WebUI.Dtos.Testimonials
{
    public class ResultTestimonialDto
    {

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public int testimonialId { get; set; }
            public string fullName { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public int rate { get; set; }
            public string imageUrl { get; set; }
        }

    }
}
