using System.Collections.Generic;
using RimWorld;
using Verse;

namespace ProgressionAttire
{

    internal static class Vanity
    {
        static readonly List<StatModifier> dressStats = new List<StatModifier> {
                    new StatModifier { stat = StatDefOf.MaxHitPoints, value = 100f },
                    new StatModifier { stat = StatDefOf.WorkToMake, value = 4300f },
                    new StatModifier { stat = StatDefOf.Mass, value = 0.8f },
                    new StatModifier { stat = StatDefOf.EquipDelay, value = 3.5f},
                    new StatModifier { stat = StatDefOf.StuffEffectMultiplierArmor, value = 0.05f },
                    new StatModifier { stat = StatDefOf.StuffEffectMultiplierInsulation_Cold, value = 0.46f },
                    new StatModifier { stat = StatDefOf.StuffEffectMultiplierInsulation_Heat, value = 0.18f },
                    new StatModifier { stat = StatDefOf.Flammability, value = 1.0f },
                    new StatModifier { stat = StatDefOf.DeteriorationRate, value = 2.0f },
                    new StatModifier { stat = StatDefOf.Beauty, value = 0.0f },
                    new StatModifier { stat = StatDefOf.SellPriceFactor, value = 0.25f }
                    };
        static readonly List<StatModifier> shirtStats = new List<StatModifier> {
                    new StatModifier { stat = StatDefOf.MaxHitPoints, value = 100f },
                    new StatModifier { stat = StatDefOf.WorkToMake, value = 2700f },
                    new StatModifier { stat = StatDefOf.Mass, value = 0.3f },
                    new StatModifier { stat = StatDefOf.EquipDelay, value = 1.5f},
                    new StatModifier { stat = StatDefOf.StuffEffectMultiplierArmor, value = 0.05f },
                    new StatModifier { stat = StatDefOf.StuffEffectMultiplierInsulation_Cold, value = 0.26f },
                    new StatModifier { stat = StatDefOf.StuffEffectMultiplierInsulation_Heat, value = 0.1f },
                    new StatModifier { stat = StatDefOf.Flammability, value = 1.0f },
                    new StatModifier { stat = StatDefOf.DeteriorationRate, value = 2.0f },
                    new StatModifier { stat = StatDefOf.Beauty, value = 0.0f },
                    new StatModifier { stat = StatDefOf.SellPriceFactor, value = 0.25f }
                    };
        static readonly List<StatModifier> pantsStats = new List<StatModifier> {
                    new StatModifier { stat = StatDefOf.MaxHitPoints, value = 100f },
                    new StatModifier { stat = StatDefOf.WorkToMake, value = 1600f },
                    new StatModifier { stat = StatDefOf.Mass, value = 0.5f },
                    new StatModifier { stat = StatDefOf.EquipDelay, value = 2.0f},
                    new StatModifier { stat = StatDefOf.StuffEffectMultiplierArmor, value = 0.05f },
                    new StatModifier { stat = StatDefOf.StuffEffectMultiplierInsulation_Cold, value = 0.2f },
                    new StatModifier { stat = StatDefOf.StuffEffectMultiplierInsulation_Heat, value = 0.08f },
                    new StatModifier { stat = StatDefOf.Flammability, value = 1.0f },
                    new StatModifier { stat = StatDefOf.DeteriorationRate, value = 2.0f },
                    new StatModifier { stat = StatDefOf.Beauty, value = 0.0f },
                    new StatModifier { stat = StatDefOf.SellPriceFactor, value = 0.25f }
                    };
        static readonly List<StatModifier> headgearStats = new List<StatModifier> {
                    new StatModifier { stat = StatDefOf.MaxHitPoints, value = 80f },
                    new StatModifier { stat = StatDefOf.WorkToMake, value = 1800f },
                    new StatModifier { stat = StatDefOf.Mass, value = 0.07f },
                    new StatModifier { stat = StatDefOf.EquipDelay, value = 0.8f },
                    new StatModifier { stat = StatDefOf.StuffEffectMultiplierArmor, value = 0.0f },
                    new StatModifier { stat = StatDefOf.StuffEffectMultiplierInsulation_Cold, value = 0.0f },
                    new StatModifier { stat = StatDefOf.StuffEffectMultiplierInsulation_Heat, value = 0.0f },
                    new StatModifier { stat = StatDefOf.Flammability, value = 1.0f },
                    new StatModifier { stat = StatDefOf.DeteriorationRate, value = 2.0f },
                    new StatModifier { stat = StatDefOf.Beauty, value = 0.0f },
                    new StatModifier { stat = StatDefOf.SellPriceFactor, value = 0.25f }
                    };
        public static int PatchApparel(ThingDef thingDef)
        {
            Utils.ApplyCategory(thingDef, "LemonSkin_VanityApparel");
            // Items made without stuff keep their fixed cost and recipe ingredients
            bool madeFromStuff = thingDef.MadeFromStuff;
            if (madeFromStuff)
            {
                thingDef.costList = new List<ThingDefCountClass>();
            }
            thingDef.equippedStatOffsets = new List<StatModifier>
                {
                    new StatModifier
                    {
                        stat = StatDefOf.SocialImpact,
                        value = 0.05f
                    },
                    new StatModifier
                    {
                        stat = StatDefOf.PawnBeauty,
                        value = 0.5f
                    },
                };

            if (thingDef.apparel.bodyPartGroups.Contains(BodyPartGroupDefOf.Torso) && thingDef.apparel.bodyPartGroups.Contains(BodyPartGroupDefOf.Legs))
            {
                thingDef.statBases = new List<StatModifier>(dressStats);
                thingDef.costStuffCount = 85;
                thingDef.equippedStatOffsets = new List<StatModifier>
                {
                    new StatModifier
                    {
                        stat = StatDefOf.SocialImpact,
                        value = 0.1f
                    },
                    new StatModifier
                    {
                        stat = StatDefOf.PawnBeauty,
                        value = 1.0f
                    },
                };
                thingDef.apparel.bodyPartGroups.RemoveAll(bpg => bpg.defName == "Hands");
                thingDef.apparel.bodyPartGroups.RemoveAll(bpg => bpg.defName == "Feet");
            }
            else if (thingDef.apparel.bodyPartGroups.Contains(BodyPartGroupDefOf.Torso))
            {
                thingDef.statBases = new List<StatModifier>(shirtStats);
                thingDef.costStuffCount = 45;
                thingDef.apparel.bodyPartGroups.RemoveAll(bpg => bpg.defName == "Hands");
                thingDef.apparel.bodyPartGroups.RemoveAll(bpg => bpg.defName == "Feet");
            }
            else if (thingDef.apparel.bodyPartGroups.Contains(BodyPartGroupDefOf.Legs))
            {
                thingDef.statBases = new List<StatModifier>(pantsStats);
                thingDef.costStuffCount = 40;
                thingDef.apparel.bodyPartGroups.RemoveAll(bpg => bpg.defName == "Hands");
                thingDef.apparel.bodyPartGroups.RemoveAll(bpg => bpg.defName == "Feet");
            }
            else if (thingDef.apparel.bodyPartGroups.Contains(BodyPartGroupDefOf.FullHead) || thingDef.apparel.bodyPartGroups.Contains(BodyPartGroupDefOf.UpperHead))
            {
                // Override base change
                Utils.ApplyCategory(thingDef, "LemonSkin_VanityHeadgear");
                thingDef.statBases = new List<StatModifier>(headgearStats);
                thingDef.costStuffCount = 45;
            }
            else
            {
                thingDef.statBases = new List<StatModifier>(headgearStats);
                thingDef.costStuffCount = 45;
            }

            thingDef.apparel.tags = new List<string>();
            thingDef.apparel.defaultOutfitTags = new List<string>();
            thingDef.tradeability = Tradeability.None;
            if (madeFromStuff)
            {
                Utils.thingDefRecipesToRegenerate.Add(thingDef);
            }

            return 1;
        }
    }


}
