using System.ComponentModel;

namespace i502Club.Ccrs.Enums
{
    public enum InventoryType
    {
        Clones = 1,
        Plant,
        Seed,
        [Description("Flower Lot")]
        FlowerLot,
        [Description("Flower Unlotted")]
        FlowerUnlotted,
        [Description("Other Material Lot")]
        OtherMaterialLot,
        [Description("Other Material Unlotted")]
        OtherMaterialUnlotted,
        [Description("Wet Flower")]
        WetFlower,
        [Description("Cannabis Mix")]
        CannabisMix,
        CBD,
        [Description("Food Grade Solvent Concentrate")]
        FoodGradeSolventConcentrate,
        [Description("Infused Cooking Medium")]
        InfusedCookingMedium,
        [Description("Cannabis Mix Infused")]
        CannabisMixInfused,
        [Description("Cannabis Mix Packaged")]
        CannabisMixPackaged,
        Capsule,
        [Description("CO2 Concentrate")]
        CO2Concentrate,
        [Description("Concentrate for Inhalation")]
        ConcentrateforInhalation,
        [Description("Ethanol Concentrate")]
        EthanolConcentrate,
        [Description("Hydrocarbon Concentrate")]
        HydrocarbonConcentrate,
        [Description("Liquid Edible")]
        LiquidEdible,
        [Description("Non-Solvent Based Concentrate")]
        NonSolventBasedConcentrate,
        [Description("Sample Jar")]
        SampleJar,
        [Description("Solid Edible")]
        SolidEdible,
        Suppository,
        Tincture,
        Transdermal,
        [Description("Topical Ointment")]
        TopicalOintment,
        [Description("Usable Cannabis")]
        UsableCannabis
    }
}
