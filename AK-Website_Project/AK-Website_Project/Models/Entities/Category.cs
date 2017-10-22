namespace AK_Website_Project.Models.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            SubCategories = new List<SubCategory>();
        }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
