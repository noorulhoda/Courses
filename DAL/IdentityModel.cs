using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationUserIdentity : IdentityUser
    {
        public Teacher teacher { set; get; }
        public Student student { set; get; }

    }


    public class ApplicationUserStore : UserStore<ApplicationUserIdentity>
    {
        public ApplicationUserStore() : base(new ApplicationDBContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }

    
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager()
            : base(new RoleStore<IdentityRole>(new ApplicationDBContext()))
        {

        }
        public ApplicationRoleManager(DbContext db)
            : base(new RoleStore<IdentityRole>(db))
        {

        }
    }


    public class ApplicationUserManager : UserManager<ApplicationUserIdentity>
    {
        public ApplicationUserManager() : base(new ApplicationUserStore())
        {

        }
        public ApplicationUserManager(DbContext db) : base(new ApplicationUserStore(db))
        {

        }
    }
    
    
    public class ApplicationDBContext : IdentityDbContext<ApplicationUserIdentity>
    {
        public ApplicationDBContext() :
            base("name=onlineCourses")//تعديل connection String and add maigration
        {

        }
        public virtual DbSet<Student> students { get; set; }
        public virtual DbSet<Teacher> teachers { get; set; }
        public virtual DbSet<Class> classes { get; set; }
        public virtual DbSet<Category> categories { get; set; }
        public virtual DbSet<Course> courses { get; set; }
    }
}
