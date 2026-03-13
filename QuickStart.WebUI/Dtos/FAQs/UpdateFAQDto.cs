namespace QuickStart.WebUI.Dtos.FAQs
{
    public class UpdateFAQDto
    {
        public int FAQId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
