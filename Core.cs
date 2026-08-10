using MelonLoader;
using Alta.Inventory;
using System.Reflection;

[assembly: MelonInfo(typeof(crystalGatherer.Core), "CrystalGatherer", "1.0.0", "MasterCats", null)]
[assembly: MelonGame("Alta", "A Township Tale")]

namespace crystalGatherer
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            category = MelonPreferences.CreateCategory("CrystalGatherer");
            earlyGame = ourFirstCategory.CreateEntry<bool>("Early Game", false);
            LoggerInstance.Msg("Initialized.");
        }
        public override void OnLateInitializeMelon()
        {

            if (earlyGame = true)
            {
               var theSkill = 38322u
            }
            else
            {
               var theSkill = 43020u
            }

            LoggerInstance.Msg("Late Initialized.");
            ProfessionSkill skill = ProfessionSkill.All.Where(skill => skill.Hash == theSkill).First(); // The Skill
            Gatherer oreGatherer = skill as Gatherer;
            Item[] validItems = (Item[])oreGatherer.GetType().GetField("validItems", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(oreGatherer);
            List<Item> validItemList = validItems.ToList();
            validItemList.AddAll(Item.All.Where(item => item.Hash == 45754u || item.Hash == 7824u));

            oreGatherer.GetType().GetField("validItems", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(oreGatherer, validItemList.ToArray());
            LoggerInstance.Msg("Ore Gatherer skill updated with new valid items.");
        }
    }
}
