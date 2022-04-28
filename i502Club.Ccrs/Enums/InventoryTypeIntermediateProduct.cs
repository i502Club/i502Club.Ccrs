using System.ComponentModel;

namespace i502Club.Ccrs.Enums
{
    public enum InventoryTypeIntermediateProduct
    {
        MarijuanaMix = 1,
        ConcentrateforInhalation,
        [Description("Non-Solvent based Concentrate")]
        NonSolventbasedConcentrate,
        HydrocarbonConcentrate,
        CO2Concentrate, 
        EthanolConcentrate,
        FoodGradeSolventConcentrate,
        InfusedCookingMedium,
        CBD,
        Waste
    }
}
