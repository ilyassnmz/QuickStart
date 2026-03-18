namespace QuickStart.WepApi.DTOs.FAQDTOs
{
    public class ResultFAQDto
    {
        public int FAQId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}