﻿using BL.Bases;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reposities
{
    public class CategoryRepository : BaseRepository<Category>
    {
        private DbContext EC_DbContext;

        public CategoryRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUD

        public List<Category> GetAllCategory()
        {
            return GetAll().ToList();
        }

        public bool InsertCategory(Category category)
        {
            return Insert(category);
        }
        public void UpdateCategory(Category category)
        {
            Update(category);
        }
        public void DeleteCategory(int id)
        {
            Delete(id);
        }

        public bool CheckCategoryExists(Category category)
        {
            return GetAny(l => l.ID == category.ID);
        }
        public Category GetCategoryById(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }
        #endregion
    }
}
