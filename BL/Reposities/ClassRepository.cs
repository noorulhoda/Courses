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
    public class ClassRepository : BaseRepository<Class>
    {
        private DbContext EC_DbContext;

        public ClassRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUD

        public List<Class> GetAllClass()
        {
            return GetAll().ToList();
        }

        public bool InsertClass(Class clas)
        {
            return Insert(clas);
        }
        public void UpdateClass(Class clas)
        {
            Update(clas);
        }
        public void DeleteClass(int id)
        {
            Delete(id);
        }

        public bool CheckClassExists(Class clas)
        {
            return GetAny(l => l.ID == clas.ID);
        }
        public Class GetClassById(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }
        #endregion
    }
}
