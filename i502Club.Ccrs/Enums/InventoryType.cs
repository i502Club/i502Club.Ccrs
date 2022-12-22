namespace i502Club.Ccrs.Enums
{
    public class InventoryType : Enumeration
    {
        public static readonly InventoryType Clones
        = new InventoryType(1, "Clones");

        public static readonly InventoryType Plant
        = new InventoryType(2, "Plant");

        public static readonly InventoryType Seed
        = new InventoryType(3, "Seed");

        public static readonly InventoryType FlowerLot
        = new InventoryType(4, "FlowerLot");

        public static readonly InventoryType FlowerUnlotted
        = new InventoryType(5, "Flower Unlotted");

        public static readonly InventoryType OtherMaterialLot
        = new InventoryType(6, "Other Material Lot");

        public static readonly InventoryType OtherMaterialUnlotted
        = new InventoryType(7, "Other Material Unlotted");

        public static readonly InventoryType WetFlower
        = new InventoryType(8, "Wet Flower");

        public static readonly InventoryType CannabisMix
        = new InventoryType(9, "Cannabis Mix");

        public static readonly InventoryType CBD
        = new InventoryType(10, "CBD");

        public static readonly InventoryType FoodGradeSolventConcentrate
        = new InventoryType(11, "Food Grade Solvent Concentrate");

        public static readonly InventoryType InfusedCookingMedium
        = new InventoryType(12, "Infused Cooking Medium");

        public static readonly InventoryType CannabisMixInfused
        = new InventoryType(13, "Cannabis Mix Infused");

        public static readonly InventoryType CannabisMixPackaged
        = new InventoryType(14, "Cannabis Mix Packaged");
        
        public static readonly InventoryType Capsule
        = new InventoryType(15, "Capsule");

        public static readonly InventoryType CO2Concentrate
        = new InventoryType(15, "CO2 Concentrate");

        public static readonly InventoryType ConcentrateforInhalation
        = new InventoryType(16, "Concentrate for Inhalation");

        public static readonly InventoryType EthanolConcentrate
        = new InventoryType(17, "Ethanol Concentrate");

        public static readonly InventoryType HydrocarbonConcentrate
        = new InventoryType(14, "Hydrocarbon Concentrate");

        public static readonly InventoryType LiquidEdible
        = new InventoryType(18, "Liquid Edible");

        public static readonly InventoryType NonSolventbasedConcentrate
        = new InventoryType(19, "Non-Solvent based Concentrate");

        public static readonly InventoryType SampleJar
        = new InventoryType(20, "Sample Jar");

        public static readonly InventoryType SolidEdible
        = new InventoryType(21, "Solid Edible");

        public static readonly InventoryType Suppository
        = new InventoryType(22, "Suppository");

        public static readonly InventoryType Tincture
        = new InventoryType(23, "Tincture");

        public static readonly InventoryType Transdermal
        = new InventoryType(24, "Transdermal");

        public static readonly InventoryType TopicalOintment
        = new InventoryType(25, "Topical Ointment");

        public static readonly InventoryType UsableCannabis
        = new InventoryType(26, "Usable Cannabis");


        public InventoryType() { }
        public InventoryType(int value, string displayName) : base(value, displayName) {
            
            //Set Category prop
            if (value < 4) { this.Category = InventoryCategory.PropagationMaterial; }
            else if (value < 9) { this.Category = InventoryCategory.HarvestedMaterial; }
            else if (value < 13) { this.Category = InventoryCategory.IntermediateProduct; }
            else { this.Category = InventoryCategory.EndProduct; }

            //Set Uom prop
            if (value < 4) { this.Uom = Uom.Each; }
            else if (value < 13) { this.Uom = Uom.Gram; }
            else { this.Uom = Uom.Each; }
        }

        public InventoryCategory Category { get; }
        public Uom Uom { get; }

    }
}
