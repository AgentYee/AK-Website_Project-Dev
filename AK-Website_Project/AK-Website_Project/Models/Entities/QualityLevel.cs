namespace AK_Website_Project.Models.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("QualityLevel")]
    public partial class QualityLevel
    {
        public QualityLevel()
        {
            Items = new List<Item>();
        }

        public int QualityLevelId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
