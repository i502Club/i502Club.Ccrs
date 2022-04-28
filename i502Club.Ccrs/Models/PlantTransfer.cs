using System;

namespace i502Club.Ccrs.Models
{
    public class PlantTransfer : BaseModel
    {
        public string FromLicenseNumber { get; set; }
        public string ToLicenseNumber { get; set; }
        public string FromExternalPlantIdentifier { get; set; }
        public string ToExternalPlantIdentifier { get; set; }
        public DateTime TransferDate { get; set; }
    }
}
