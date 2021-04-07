using BL.Interfaces;
using BL.Reposities;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Common Properties
        private DbContext context { get; set; }

        #endregion

        #region Constructors
        public UnitOfWork()
        {
            context = new ApplicationDBContext();
            context.Configuration.LazyLoadingEnabled = false;
        }
        #endregion

        #region Methods
        public int Commit()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
        #endregion


        public CommentRepository comment;
        public CommentRepository Comment
        {
            get
            {
                if (comment == null)
                    comment= new CommentRepository(context);
                return comment;
            }
        }
        public StudentRepository student;
        public StudentRepository Student
        {
            get
            {
                if (student == null)
                    student = new StudentRepository(context);
                return student;
            }
        }


        public TeacherRepository teacher;
        public TeacherRepository Teacher
        {
            get
            {
                if (teacher == null)
                    teacher = new TeacherRepository(context);
                return teacher;
            }
        }

        public ClassRepository clas;
        public ClassRepository Class
        {
            get
            {
                if (clas == null)
                    clas = new ClassRepository(context);
                return clas;
            }
        }

        public CourseRepository course;
        public CourseRepository Course
        {
            get
            {
                if (course == null)
                    course = new CourseRepository(context);
                return course;
            }
        }

        public CategoryRepository category;
        public CategoryRepository Category
        {
            get
            {
                if (category == null)
                    category = new CategoryRepository(context);
                return category;
            }
        }

        public AccountRepository account;
        public AccountRepository Account
        {
            get
            {
                if (account == null)
                    account = new AccountRepository(context);
                return account;
            }
        }

        public RoleRepository role;
        public RoleRepository Role
        {
            get
            {
                if (role == null)
                    role = new RoleRepository(context);
                return role;
            }
        }
    }
}
