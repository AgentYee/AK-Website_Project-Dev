namespace AK_Website_Project.Models.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public partial class User
    {
        public User()
        {
            Comments = new List<Comment>();
        }

        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int? PictureId { get; set; }

        public int RoleId { get; set; }

        public string Desciption { get; set; }

        public double? Rating { get; set; }

        public bool IsDisabled { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Picture Picture { get; set; }

        public virtual Role Role { get; set; }
    }
}
