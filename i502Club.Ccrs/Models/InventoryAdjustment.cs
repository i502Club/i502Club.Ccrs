using i502Club.Ccrs.Enums;
using System;

namespace i502Club.Ccrs.Models
{
    public class InventoryAdjustment : BaseModel
    {
        public string LicenseNumber { get; set; }
        public string InventoryExternalIdentifier { get; set; }
        public AdjustmentReason AdjustmentReason { get; set; }
        public string AdjustmentDetail { get; set; }
        public decimal Quantity { get; set; }
        public DateTime AdjustmentDate { get; set; }
    }
}
