namespace QuickStart.WebApiLayer.DTOs.PricingDTOs
{
    public class UpdatePricingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Period { get; set; }
        public bool IsFeatured { get; set; }
        public List<string> Features { get; set; }
    }
}
