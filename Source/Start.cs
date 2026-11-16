using Verse;

namespace ProgressionAttire
{
    [StaticConstructorOnStartup]
    public static class Start
    {
        static Start()
        {
            ThingDef vanityTable = DefDatabase<ThingDef>.GetNamed("Ferny_VanityTable", false);
            ThingDef costumingTable = DefDatabase<ThingDef>.GetNamed("Ferny_CostumingTable", false);
            int vanityItemsPatched = 0;
            int costumeItemsPatched = 0;
            foreach (ThingDef thingDef in DefDatabase<ThingDef>.AllDefs)
            {
                if (thingDef.recipeMaker?.recipeUsers?.Contains(vanityTable) == true)
                {
                    vanityItemsPatched += Vanity.PatchApparel(thingDef);
                }
                if (thingDef.recipeMaker?.recipeUsers?.Contains(costumingTable) == true)
                {
                    costumeItemsPatched += Costume.PatchApparel(thingDef);
                }
            }
            Utils.RefreshModifiedCategories();
            Utils.RefreshAllModifiedRecipes();
            Log.Message($"ProgressionLESS: Attire: Patched {vanityItemsPatched} vanity items & {costumeItemsPatched} costume items");
            Log.Message("ProgressionLESS: Attire loaded successfully");
        }
    }
}
