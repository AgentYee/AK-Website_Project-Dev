using System.Collections.Generic;

namespace AK_Website_Project.Models.ViewModels.Home
{
    public class HomeViewModel
    {
        public List<string> CraftingList { get; private set; }
        public List<string> FishingList { get; private set; }
        public List<string> GatheringList { get; private set; }
        public List<string> AlchemyList { get; private set; }
        public List<string> CookingList { get; private set; }

        public HomeViewModel()
        {
            CraftingList = getCraftingList();
            FishingList = getFishingList();
            GatheringList = getGatheringList();
            AlchemyList = getAlchemyList();
            CookingList = getCookingList();
        }
        //Hardcoded for now
        private List<string> getCraftingList()
        {
            List<string> templist = new List<string>();
            templist.Add("Lv.70 Sniper");
            templist.Add("Lv.80 Lordswrath");
            templist.Add("Lv.90 Holy Spirit");
            return templist;
        }
        //Hardcoded for now
        private List<string> getFishingList()
        {
            List<string> templist = new List<string>();
            templist.Add("Lv.8 Gear");
            templist.Add("Lv.7 Gear");
            templist.Add("Lv.6 Gear");
            return templist;
        }
        //Hardcoded for now
        private List<string> getGatheringList()
        {
            List<string> templist = new List<string>();
            templist.Add("Tempest Desert");
            templist.Add("Chronowood Forest");
            templist.Add("Sunhunter's Vale");
            templist.Add("Tanglevines Cascade");
            return templist;
        }
        //Hardcoded for now
        private List<string> getAlchemyList()
        {
            List<string> templist = new List<string>();
            templist.Add("Elixirs");
            templist.Add("Tonics");
            return templist;
        }
        //Hardcoded for now
        private List<string> getCookingList()
        {
            List<string> templist = new List<string>();
            templist.Add("Lv.80 Foods");
            templist.Add("Lv.75 Foods");
            templist.Add("Lv.70 Foods");
            return templist;
        }
    }
}