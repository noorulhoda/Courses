using BL.Bases;
using BL.ViewModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reposities
{
    public class CourseRepository : BaseRepository<Course>
    {
        private DbContext EC_DbContext;

        public CourseRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUD

        public List<Course> GetAllCourse()
        {
            return GetAll().ToList();
        }

        public bool InsertCourse(Course course)
        {
            return Insert(course);
        }
        public void UpdateCourse(Course course)
        {
            Update(course);
        }
        public void DeleteCourse(int id)
        {
            Delete(id);
        }

        public bool CheckCourseExists(Course course)
        {
            return GetAny(l => l.ID == course.ID);
        }
        public Course GetCourseById(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }
        public List<Course> GetCourseByName(string name)
        {
            return GetAll().Where(l => l.title == name).ToList();
        }

        public bool EnrollStudent(int courseId,Student student)
        {
            Course course = GetById(courseId);
           
            if (course.classes !=null)
            {
                if (course.classes.ElementAt(course.classes.Count - 1).students.Count < 10)
                {
                    course.classes.ElementAt(course.classes.Count - 1).students.Add(student);
                    return true;
                }
                else
                {
                    Class nClass = new Class() {number='n'};

                    course.classes.Add(nClass);
                    course.classes.FirstOrDefault(c=>c.ID==nClass.ID).students.Add(student);
                    return true;
                }
                   
            }
            else
            {
                Class nClass = new Class() { number = 'n' };
                course.classes = new List<Class>();
                course.classes.Add(nClass);
                var stds = course.classes.FirstOrDefault(c => c.ID == nClass.ID).students;
                if (stds!=null){
                    stds.Add(student); 
                }
                else
                {
                    course.classes.FirstOrDefault(c => c.ID == nClass.ID).students = new List<Student>();
                    course.classes.FirstOrDefault(c => c.ID == nClass.ID).students.Add(student);
                }

                return true;
            }
            return false;
        }
        #endregion
    }
}
