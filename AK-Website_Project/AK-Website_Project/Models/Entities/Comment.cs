//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AK_Website_Project.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int AttachedToItemId { get; set; }
        public int CreatorId { get; set; }
        public Nullable<double> Rating { get; set; }
        public Nullable<int> RateCount { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual User User { get; set; }
    }
}
