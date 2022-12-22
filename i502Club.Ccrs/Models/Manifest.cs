namespace i502Club.Ccrs.Models
{
    public class Manifest : BaseModel
    {
        public string InventoryExternalIdentifier { get; set; }
        public string PlantExternalIdentifier { get; set; }
        public decimal Quantity { get; set; }
        public string UOM { get; set; }
        public decimal? WeightPerUnit { get; set; }
        public decimal? ServingsPerUnit { get; set; }
    }
}
