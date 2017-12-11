using AK_Website_Project.DAL.Interface;
using AK_Website_Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AK_Website_Project.DAL
{
    public class CommentDao : ICommentDao
    {
        public bool PostComment(Comment comment)
        {
            int result = -1;

            using (Entities ctx = new Entities())
            {
                ctx.Comments.Add(comment);
                result = ctx.SaveChanges();
            }

            if(result != -1)
            {
                return true;
            }
            return false;
        }
    }
}