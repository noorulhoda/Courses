using AutoMapper;
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
    public class StudentRepository : BaseRepository<Student>
    {
        private DbContext EC_DbContext;

        public StudentRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUD

        public List<Student> GetAllStudent()
        {
            List<Student> s= GetAll().ToList();
            return s;
        }

        public bool InsertStudent(Student student)
        {
            return Insert(student);
        }
        public void UpdateStudent(Student student)
        {
            Update(student);
        }

      
        public void DeleteStudent(int id)
        {
            Delete(id);
        }

        public bool CheckStudentExists(Student student)
        {
            return GetAny(l => l.ID == student.ID);
        }
        public Student GetStudentById(string id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }
        #endregion
    }
}
