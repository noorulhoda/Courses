﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.Data
{
    public class WebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebContext() : base("name=WebContext")
        {
        }

        public System.Data.Entity.DbSet<BL.ViewModels.StudentVM> StudentVMs { get; set; }

        public System.Data.Entity.DbSet<BL.ViewModels.RegisterVM> RegisterVMs { get; set; }

        public System.Data.Entity.DbSet<BL.ViewModels.ClassVM> ClassVMs { get; set; }
    }
}
