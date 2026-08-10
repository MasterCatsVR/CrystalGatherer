using MelonLoader;
using Alta.Inventory;
using System.Reflection;

[assembly: MelonInfo(typeof(crystalGatherer.Core), "CrystalGatherer", "1.1.0", "MasterCats", null)]
[assembly: MelonGame("Alta", "A Township Tale")]

namespace crystalGatherer
{
    public class Core : MelonMod
    {

        private MelonPreferences_Category category;
        private MelonPreferences_Entry<bool> earlyGame;
        uint theSkill;
        string skillType;
        public override void OnInitializeMelon()
        {
            category = MelonPreferences.CreateCategory("CrystalGatherer");
            earlyGame = category.CreateEntry<bool>("StoneGatherer", false); // defaults to false, making it ore gatherer.
            MelonPreferences.Save(); 

            if (earlyGame.Value)
            {
               theSkill = 38322u; // Basic Stone Gatherer
               skillType = "Basic Stone";
            }
            else
            {
               theSkill = 43020u; // Ore Gatherer
               skillType = "Ore";
            }
            LoggerInstance.Msg("Initialized.");
        }
        public override void OnLateInitializeMelon()
        {
            LoggerInstance.Msg("Late Initialized.");
            ProfessionSkill skill = ProfessionSkill.All.Where(skill => skill.Hash == theSkill).First(); // edits either of the skills above depending on the config.
            Gatherer oreGatherer = skill as Gatherer;
            Item[] validItems = (Item[])oreGatherer.GetType().GetField("validItems", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(oreGatherer);
            List<Item> validItemList = validItems.ToList();
            validItemList.AddAll(Item.All.Where(item => item.Hash == 45754u || item.Hash == 7824u));

            oreGatherer.GetType().GetField("validItems", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(oreGatherer, validItemList.ToArray());
            LoggerInstance.Msg(skillType + " Gatherer skill updated with new valid items.");
        }
    }
}
