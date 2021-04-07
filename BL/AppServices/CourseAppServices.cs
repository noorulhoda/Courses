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
    public class CourseAppServices : BaseAppServices
    {
        #region CURD

        public List<CourseVM> GetAllCourse()
        {

            return Mapper.Map<List<CourseVM>>(TheUnitOfWork.Course.GetAllCourse());
        }
        public CourseVM GetCourse(int id)
        {
            return Mapper.Map<CourseVM>(TheUnitOfWork.Course.GetCourseById(id));
        }

        public List<CourseVM> GetCourseByName(string name)
        {
            return Mapper.Map<List<CourseVM>>(TheUnitOfWork.Course.GetCourseByName(name));
        }

        public bool SaveNewCourse(CourseVM courseVM)
        {
            bool result = false;
            var course = Mapper.Map<Course>(courseVM);
            if (TheUnitOfWork.Course.Insert(course))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateCourse(CourseVM courseVM)
        {
            var course = Mapper.Map<Course>(courseVM);
            TheUnitOfWork.Course.Update(course);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteCourse(int id)
        {
            bool result = false;

            TheUnitOfWork.Course.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckCourseExists(CourseVM courseVM)
        {
            Course course = Mapper.Map<Course>(courseVM);
            return TheUnitOfWork.Course.CheckCourseExists(course);
        }
        #endregion
        public bool EnrollStudent(int courseId,StudentVM studentvm)
        {
            try
            {
                Student student = TheUnitOfWork.Student.GetById(studentvm.ID);
                TheUnitOfWork.Course.EnrollStudent(courseId, student);
                return true;
            }
            catch
            {
                return false;
            }
         
        }
    }
}
