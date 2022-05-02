using i502Club.Ccrs.Enums;

namespace i502Club.Ccrs.Models
{
    public class Product : BaseModel
    {
        public string LicenseNumber { get; set; }
        public InventoryCategory InventoryCategory { get; set; }
        public InventoryType InventoryType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitWeightGrams { get; set; }
    }
}
