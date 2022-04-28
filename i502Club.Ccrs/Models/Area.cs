namespace i502Club.Ccrs.Models
{
    public class Area : BaseModel
    {
        public string LicenseNumber { get; set; }
        public string Name { get; set; }
        public bool IsQuarantine { get; set; }
    }
}
