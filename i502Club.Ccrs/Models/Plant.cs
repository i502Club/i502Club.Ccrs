using i502Club.Ccrs.Enums;
using System;

namespace i502Club.Ccrs.Models
{
    public class Plant : BaseModel
    {
        public string LicenseNumber { get; set; }
        public string PlantIdentifier { get; set; }
        public string Area { get; set; }
        public string Strain { get; set; }
        public PlantSource PlantSource { get; set; }
        public PlantState PlantState { get; set; }
        public GrowthStage GrowthStage { get; set; }
        public string MotherPlantExternalIdentifier { get; set; }
        public DateTime? HarvestDate { get; set; }
        public bool IsMotherPlant { get; set; }
    }
}
