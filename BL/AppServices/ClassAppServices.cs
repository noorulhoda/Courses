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
   public class ClassAppServices : BaseAppServices
    {
    

        public Class GetById(int id)
        {
            return TheUnitOfWork.Class.GetById(id);
        }
        public ClassVM GetVMById(int id)
        {
            Class clas = GetById(id);
            ClassVM classvm = new ClassVM()
            {
               

            };
            return classvm;
        }
        #region CURD
        public List<ClassVM> GetAllClass()
        {
            return Mapper.Map<List<ClassVM>>(TheUnitOfWork.Class.GetAllClass());
        }
        public ClassVM GetClass(int id)
        {
            return Mapper.Map<ClassVM>(TheUnitOfWork.Class.GetClassById(id));
        }
        public bool SaveNewClass(ClassVM classVM)
        {
            bool result = false;
            var clas = Mapper.Map<Class>(classVM);
            if (TheUnitOfWork.Class.Insert(clas))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateClass(ClassVM classVM)
        {
            var clas = Mapper.Map<Class>(classVM);
            TheUnitOfWork.Class.Update(clas);
            TheUnitOfWork.Commit();
            return true;
        }
        public bool DeleteClass(int id)
        {
            bool result = false;
            TheUnitOfWork.Class.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public bool CheckClassExists(ClassVM classVM)
        {
            Class clas = Mapper.Map<Class>(classVM);
            return TheUnitOfWork.Class.CheckClassExists(clas);
        }
        #endregion






    }
}
