namespace AK_Website_Project.Models.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Comment")]
    public partial class Comment
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        public int AttachedToItemId { get; set; }

        public int CreatorId { get; set; }

        public double? Rating { get; set; }

        public int? RateCount { get; set; }

        public virtual Item Item { get; set; }

        public virtual User User { get; set; }
    }
}
