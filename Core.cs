using MelonLoader;
using Alta.Inventory;
using System.Reflection;

[assembly: MelonInfo(typeof(enhancedHunterSkills.Core), "enhancedHunterSkills", "1.0.1", "TheRavenSeb", null)]
[assembly: MelonGame("Alta", "A Township Tale")]

namespace enhancedHunterSkills
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }
        public override void OnLateInitializeMelon()
        {
            LoggerInstance.Msg("Late Initialized.");
            ProfessionSkill skill = ProfessionSkill.All.Where(skill => skill.Hash == 40172u).First(); // this is FeatherGatherer
            Gatherer featherGatherer = skill as Gatherer;
            Item[] validItems = (Item[])featherGatherer.GetType().GetField("validItems", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(featherGatherer);
            List<Item> validItemList = validItems.ToList();
            validItemList.AddAll(Item.All.Where(item => item.Hash == 5268u || item.Hash == 49918u || item.Hash == 8392u || item.Hash == 5924u || item.Hash ==  || item.Hash == ));

            featherGatherer.GetType().GetField("validItems", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(featherGatherer, validItemList.ToArray());
            LoggerInstance.Msg("FeatherGatherer skill updated with new valid items.");
        }
    }
}