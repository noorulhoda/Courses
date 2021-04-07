using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reposities
{
    public class CommentRepository : BaseRepository<Comment>
    {
        private DbContext EC_DbContext;

        public CommentRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUD

        public List<Comment> GetAllComment()
        {
            return GetAll().ToList();
        }

        public bool InsertComment(Comment comment)
        {
            return Insert(comment);
        }
        public void UpdateComment(Comment comment)
        {
            Update(comment);
        }
        public void DeleteComment(int id)
        {
            Delete(id);
        }

        public bool CheckCommentExists(Comment comment)
        {
            return GetAny(l => l.ID == comment.ID);
        }
        public Comment GetCommentById(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }
        #endregion
    }
}
