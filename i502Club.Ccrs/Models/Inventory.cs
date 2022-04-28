namespace i502Club.Ccrs.Models
{
    public class Inventory : BaseModel
    {
        public string LicenseNumber { get; set; }
        public string Strain { get; set; }
        public string Area { get; set; }
        public string Product { get; set; }
        public decimal? InitialQuantity { get; set; }
        public decimal QuantityOnHand { get; set; }
        public decimal? TotalCost { get; set; }
        public bool IsMedical { get; set; }
    }
}
