namespace AK_Website_Project.Models.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Picture")]
    public partial class Picture
    {
        public Picture()
        {
            Items = new List<Item>();
            Users = new List<User>();
        }

        public int PictureId { get; set; }

        public string Path { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
