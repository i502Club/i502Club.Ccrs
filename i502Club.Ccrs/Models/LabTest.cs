using System;

namespace i502Club.Ccrs.Models
{
    public class LabTest : BaseModel
    {
        public string LicenseNumber { get; set; }
        public string InventoryExternalIdentifier { get; set; }
        public string LabLicenseNumber { get; set; }
        public string LabTestStatus { get; set; }
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public string TestValue { get; set; }
    }
}
