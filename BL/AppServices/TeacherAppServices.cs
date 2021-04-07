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
   public class TeacherAppServices : BaseAppServices
    {
        #region CURD

        public List<TeacherVM> GetAllTeacher()
        {

            return Mapper.Map<List<TeacherVM>>(TheUnitOfWork.Teacher.GetAllTeacher());
        }
        public TeacherVM GetTeacher(string id)
        {
            return Mapper.Map<TeacherVM>(TheUnitOfWork.Teacher.GetTeacherById(id));
        }



        public bool SaveNewTeacher(TeacherVM teacherVM)
        {
            bool result = false;
            var teacher = Mapper.Map<Teacher>(teacherVM);
            if (TheUnitOfWork.Teacher.Insert(teacher))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateTeacher(TeacherVM teacherVM)
        {
            var teacher = Mapper.Map<Teacher>(teacherVM);
            teacher.user.Id = teacher.ID;
            TheUnitOfWork.Teacher.Update(teacher);
            TheUnitOfWork.Commit();

            return true;
        }
        public Teacher GetById(string id)
        {
            return TheUnitOfWork.Teacher.GetById(id);
        }
        public TeacherVM GetVMById(string id)
        {
           Teacher teacher = GetById(id);
            TeacherVM teachervm = new TeacherVM()
            {
                ID = teacher.ID,
                age = teacher.age,
                firstName = teacher.firstName,
                lastName = teacher.lastName,
                user = teacher.user,
                image = teacher.image,
                gender = teacher.gender

            };
            return teachervm;
        }
        public bool DeleteTeacher(string id)
        {
            bool result = false;
            Teacher t = TheUnitOfWork.Teacher.GetById(id);
            TheUnitOfWork.Teacher.Delete(t);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckTeacherExists(TeacherVM teacherVM)
        {
            Teacher teacher = Mapper.Map<Teacher>(teacherVM);
            return TheUnitOfWork.Teacher.CheckTeacherExists(teacher);
        }
        #endregion

    }
}
