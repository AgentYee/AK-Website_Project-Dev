namespace AK_Website_Project.Models.ViewModels.Comment
{
    public class CommentViewModel
    {
        public int CommentId;
        public string Content;
        public int AttachedToItemId;
        public int CreatorId;
        public float Rating;
        public int RateCount;
    }
}