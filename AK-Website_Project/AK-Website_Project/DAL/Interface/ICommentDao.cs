using AK_Website_Project.Models.Entities;

namespace AK_Website_Project.DAL.Interface
{
    public interface ICommentDao
    {
        bool PostComment(Comment comment);
    }
}
