using AK_Website_Project.DAL.Interface;
using AK_Website_Project.Models.Entities;
using AK_Website_Project.Repository.Interface;
using System;

namespace AK_Website_Project.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ICommentDao dao;

        public CommentRepository(ICommentDao dao)
        {
            this.dao = dao;
        }
        public bool PostComment(Comment comment)
        {
            return dao.PostComment(comment);
        }
    }
}