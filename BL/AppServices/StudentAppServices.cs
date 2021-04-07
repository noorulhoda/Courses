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
   public class StudentAppServices : BaseAppServices
    {
        #region CURD

        public List<StudentVM> GetAllStudent()
        {

            return Mapper.Map<List<StudentVM>>(TheUnitOfWork.Student.GetAllStudent());
        }
        public StudentVM GetStudent(string id)
        {
            return Mapper.Map<StudentVM>(TheUnitOfWork.Student.GetStudentById(id));
        }



        public bool SaveNewStudent(StudentVM studentVM)
        {
            bool result = false;
            var student = Mapper.Map<Student>(studentVM);
            if (TheUnitOfWork.Student.Insert(student))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateStudent(StudentVM studentVM)
        {
            var student = Mapper.Map<Student>(studentVM);
            student.user.Id = student.ID;
            TheUnitOfWork.Student.Update(student);
            TheUnitOfWork.Commit();

            return true;
        }
     

        public bool DeleteStudent(string id)
        {
            bool result = false;
            Student s=TheUnitOfWork.Student.GetById(id);
            TheUnitOfWork.Student.Delete(s);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckStudentExists(StudentVM studentVM)
        {
            Student student = Mapper.Map<Student>(studentVM);
            return TheUnitOfWork.Student.CheckStudentExists(student);
        }

        public  Student GetById(string id)
        {
            return TheUnitOfWork.Student.GetById(id);
        }

        public StudentVM GetVMById(string id)
        {
          Student student= GetById(id);
            StudentVM studentvm = new StudentVM()
            {
                ID = student.ID,
                age = student.age,
                firstName = student.firstName,
                lastName = student.lastName,
                user = student.user,
                image=student.image,
                gender=student.gender

            };
            return studentvm;
        }
        #endregion

    }
}
