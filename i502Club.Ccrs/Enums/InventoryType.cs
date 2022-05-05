namespace i502Club.Ccrs.Enums
{
    /// <summary>
    /// Experimental Superset Enumeration Class which includes all 
    /// InventoryCategory InventoryTypes. Standardized enum key have 
    /// been altered with InventoryCategory suffixes to allow for 
    /// a single Enum. Category and Uom props eliminate the typical 
    /// need for switch or if's using normal Enums.
    /// </summary>
    public class InventoryType : Enumeration
    {

        public static readonly InventoryType Seed
        = new InventoryType(1, "Seed");

        public static readonly InventoryType Plant
        = new InventoryType(2, "Plant");

        public static readonly InventoryType WetFlower
        = new InventoryType(3, "Wet Flower");

        public static readonly InventoryType WetOtherMaterial
        = new InventoryType(4, "Wet Other Material");

        public static readonly InventoryType FlowerUnlotted
        = new InventoryType(5, "Flower Unlotted");

        public static readonly InventoryType FlowerLot
        = new InventoryType(6, "Flower Lot");

        public static readonly InventoryType OtherMaterialUnlotted
        = new InventoryType(7, "Other Material Unlotted");

        public static readonly InventoryType OtherMaterialLot
        = new InventoryType(8, "Other Material Lot");

        public static readonly InventoryType WasteHarvestMaterial
        = new InventoryType(9, "Waste Harvest Material");

        public static readonly InventoryType MarijuanaMixHarvestMaterial
        = new InventoryType(10, "Marijuana Mix Harvest Material");

        public static readonly InventoryType MarijuanaMixIntermediateProduct
        = new InventoryType(11, "Marijuana Mix Intermediate Product");

        public static readonly InventoryType ConcentrateforInhalation
        = new InventoryType(12, "Concentrate for Inhalation");

        public static readonly InventoryType NonSolventbasedConcentrate
        = new InventoryType(13, "Non-Solvent based Concentrate");

        public static readonly InventoryType HydrocarbonConcentrate
        = new InventoryType(14, "Hydrocarbon Concentrate");

        public static readonly InventoryType CO2Concentrate
        = new InventoryType(15, "CO2 Concentrate");

        public static readonly InventoryType EthanolConcentrate
        = new InventoryType(16, "Ethanol Concentrate");

        public static readonly InventoryType FoodGradeSolventConcentrate
        = new InventoryType(17, "FoodGrade Solvent Concentrate");

        public static readonly InventoryType InfusedCookingMedium
        = new InventoryType(18, "Infused Cooking Medium");

        public static readonly InventoryType CBD
        = new InventoryType(19, "CBD");

        public static readonly InventoryType WasteIntermediateProduct
        = new InventoryType(20, "Waste Intermediate Product");

        public static readonly InventoryType Capsule
        = new InventoryType(21, "Capsule");

        public static readonly InventoryType SolidEdible
        = new InventoryType(22, "Solid Edible");

        public static readonly InventoryType Tincture
        = new InventoryType(23, "Tincture");

        public static readonly InventoryType LiquidEdible
        = new InventoryType(24, "Liquid Edible");

        public static readonly InventoryType Transdermal
        = new InventoryType(25, "Transdermal");

        public static readonly InventoryType TopicalOintment
        = new InventoryType(26, "Topical Ointment");

        public static readonly InventoryType MarijuanaMixPackaged
        = new InventoryType(27, "Marijuana Mix Packaged");

        public static readonly InventoryType MarijuanaMixInfused
        = new InventoryType(28, "Marijuana Mix Infused");

        public static readonly InventoryType Suppository
        = new InventoryType(29, "Suppository");

        public static readonly InventoryType UsableMarijuana
        = new InventoryType(30, "Usable Marijuana");

        public static readonly InventoryType SampleJar
        = new InventoryType(31, "Sample Jar");

        public static readonly InventoryType WasteEndProduct
        = new InventoryType(32, "Waste End Product");

        public InventoryType() { }
        public InventoryType(int value, string displayName) : base(value, displayName) {
            
            //Set Category prop
            if (value < 3) { this.Category = InventoryCategory.PropagationMaterial; }
            else if (value < 11) { this.Category = InventoryCategory.HarvestedMaterial; }
            else if (value < 21) { this.Category = InventoryCategory.IntermediateProduct; }
            else { this.Category = InventoryCategory.EndProduct; }

            //Set Uom prop
            if (value < 3) { this.Uom = Uom.Each; }
            else if (value < 21) { this.Uom = Uom.Gram; }
            else { this.Uom = Uom.Each; }
        }

        public InventoryCategory Category { get; }
        public Uom Uom { get; }

    }
}
