using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using UnityEngine;
using Verse;
using Verse.AI;
using Verse.AI.Group;
using Verse.Sound;
using Verse.Noise;
using Verse.Grammar;
using RimWorld;
using RimWorld.Planet;

// *Uncomment for Harmony*
using System.Reflection;
using HarmonyLib;

namespace ProgressionAttire
{
    [StaticConstructorOnStartup]
    public static class Start
    {
        static Start()
        {
            int vanityItemsPatched = 0;
            int costumeItemsPatched = 0;
            foreach (ThingDef thingDef in DefDatabase<ThingDef>.AllDefs)
            {
                if (thingDef.recipeMaker?.recipeUsers?.Contains(DefDatabase<ThingDef>.GetNamed("Ferny_VanityTable", false)) == true)
                {
                    vanityItemsPatched += Vanity.PatchApparel(thingDef);
                }
                if (thingDef.recipeMaker?.recipeUsers?.Contains(DefDatabase<ThingDef>.GetNamed("Ferny_CostumingTable", false)) == true)
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
