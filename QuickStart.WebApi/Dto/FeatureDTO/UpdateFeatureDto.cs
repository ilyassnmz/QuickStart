namespace QuickStart.WebApi.Dto
{
    public class UpdateFeatureDto
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
    }
}