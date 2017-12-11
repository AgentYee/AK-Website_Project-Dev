using AK_Website_Project.Models.Entities;

namespace AK_Website_Project.Repository.Interface
{
    public interface ICommentRepository
    {
        bool PostComment(Comment comment);
    }
}
