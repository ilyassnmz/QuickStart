namespace QuickStart.WebUI.Dtos.ContactInfos
{
    public class UpdateContactInfoDto
    {
        public int ContactInfoId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MapLocation { get; set; }
    }
}
