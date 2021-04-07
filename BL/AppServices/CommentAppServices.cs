using BL.Bases;
using BL.ViewModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.AppServices
{
    public class CommentAppServices : BaseAppServices
    {
        #region CURD

        public Comment GetById(int id)
        {
            return TheUnitOfWork.Comment.GetById(id);
        }
        public CommentVM GetVMById(int id)
        {
            Comment comment = GetById(id);
            CommentVM commentsvm = new CommentVM()
            {


            };
            return commentsvm;
        }
        public List<CommentVM> GetAllComment()
        {

            return Mapper.Map<List<CommentVM>>(TheUnitOfWork.Comment.GetAllComment());
        }
        public CommentVM GetStudent(int id)
        {
            return Mapper.Map<CommentVM>(TheUnitOfWork.Comment.GetCommentById(id));
        }


        public bool SaveNewComment(CommentVM commentVM)
        {
            bool result = false;
            var comment = Mapper.Map<Comment>(commentVM);
            if (TheUnitOfWork.Comment.Insert(comment))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateComment(Comment comment)
        {
            var commentss = Mapper.Map<Comment>(comment);
            TheUnitOfWork.Comment.Update(commentss);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteComment(int id)
        {
            bool result = false;

            TheUnitOfWork.Comment.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckCommentExists(Comment comment)
        {
            Comment commentss = Mapper.Map<Comment>(comment);
            return TheUnitOfWork.Comment.CheckCommentExists(commentss);
        }




        #endregion

    }
}
