namespace AK_Website_Project.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        public Item()
        {
            Comments = new HashSet<Comment>();
        }

        public int ItemId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int SubCategoryId { get; set; }

        public int? PictureId { get; set; }

        public bool IsCommentsAllowed { get; set; }

        public int QualityLevelId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Picture Picture { get; set; }

        public virtual QualityLevel QualityLevel { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
