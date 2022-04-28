using i502Club.Ccrs.Enums;
using System;

namespace i502Club.Ccrs.Models
{
    public class Sale : BaseModel
    {
        public string LicenseNumber { get; set; }
        public string SoldToLicenseNumber { get; set; }
        public string InventoryExternalIdentifier { get; set; }
        public string PlantExternalIdentifier { get; set; }
        public SaleType SaleType { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? SalesTax { get; set; }
        public decimal? OtherTax { get; set; }
        public string SaleExternalIdentifier { get; set; }
        public string SaleDetailExternalIdentifier { get; set; }
    }
}
