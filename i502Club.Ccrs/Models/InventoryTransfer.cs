using System;

namespace i502Club.Ccrs.Models
{
    public class InventoryTransfer : BaseModel
    {
        public string FromLicenseNumber { get; set; }
        public string ToLicenseNumber { get; set; }
        public string FromInventoryExternalIdentifier { get; set; }
        public string ToInventoryExternalIdentifier { get; set; }
        public decimal Quantity { get; set; }
        public DateTime TransferDate { get; set; }
    }
}
