namespace AK_Website_Project.Models.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SubCategory")]
    public partial class SubCategory
    {
        public SubCategory()
        {
            Items = new List<Item>();
        }

        public int SubCategoryId { get; set; }

        public string Name { get; set; }

        public int ParentCategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
