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
    public class TeacherRepository : BaseRepository<Teacher>
    {
        private DbContext EC_DbContext;

        public TeacherRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<Teacher> GetAllTeacher()
        {
            return GetAll().ToList();
        }

        public bool InsertTeacher(Teacher teacher)
        {
            return Insert(teacher);
        }
        public void UpdateTeacher(Teacher teacher)
        {
            Update(teacher);
        }
        public void DeleteTeacher(int id)
        {
            Delete(id);
        }

        public bool CheckTeacherExists(Teacher teacher)
        {
            return GetAny(l => l.ID == teacher.ID);
        }
        public Teacher GetTeacherById(string id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }
        #endregion
    }
}
