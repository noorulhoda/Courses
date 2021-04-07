using BL.Reposities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Methode
        int Commit();
        #endregion
        StudentRepository Student { get; } 
        TeacherRepository Teacher { get; } 
        CourseRepository Course { get; }
        ClassRepository Class { get; }
        CategoryRepository Category { get; }
        CommentRepository Comment { get; }
        AccountRepository Account { get; }
        RoleRepository Role { get; }

    }
}
