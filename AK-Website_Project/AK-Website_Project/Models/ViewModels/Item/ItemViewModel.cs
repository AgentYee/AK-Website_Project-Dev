using AK_Website_Project.Models.Entities;

namespace AK_Website_Project.Models.ViewModels.Item
{
    public class ItemViewModel
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public QualityLevel QualityLevel { get; set; }
        public int SubCategoryId { get; set; }
    }
}