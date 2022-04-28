using i502Club.Ccrs.Enums;
using System;

namespace i502Club.Ccrs.Models
{
    public class PlantDestruction : BaseModel
    {
        public string LicenseNumber { get; set; }
        public string PlantExternalIdentifier { get; set; }
        public DestructionReason DestructionReason { get; set; }
        public DestructionMethod DestructionMethod { get; set; }
        public DateTime DestructionDate { get; set; }
    }
}
