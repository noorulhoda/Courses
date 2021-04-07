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
    public class CategoryAppServices : BaseAppServices
    {
        #region CURD

        public List<CategoryVM> GetAllCategory()
        {

            return Mapper.Map<List<CategoryVM>>(TheUnitOfWork.Category.GetAllCategory());
        }
        public CategoryVM GetCategory(int id)
        {
            return Mapper.Map<CategoryVM>(TheUnitOfWork.Category.GetCategoryById(id));
        }
        public bool SaveNewCategory(CategoryVM categoryVM)
        {
            bool result = false;
            var category = Mapper.Map<Category>(categoryVM);
            if (TheUnitOfWork.Category.Insert(category))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateCategory(CategoryVM categoryVM)
        {
            var category = Mapper.Map<Category>(categoryVM);
            TheUnitOfWork.Category.Update(category);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteCategory(int id)
        {
            bool result = false;

            TheUnitOfWork.Category.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckCategoryExists(CategoryVM categoryVM)
        {
            Category category = Mapper.Map<Category>(categoryVM);
            return TheUnitOfWork.Category.CheckCategoryExists(category);
        }
        #endregion

    }
}
