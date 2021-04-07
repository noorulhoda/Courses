using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Reposities
{
    public class AccountRepository
    {
        
        ApplicationUserManager manager;

        public AccountRepository(DbContext db)
        {
           
            manager = new ApplicationUserManager(db);
        }
        public ApplicationUserIdentity Find(string username, string password)
        {
            ApplicationUserIdentity result = manager.Find(username, password);
            return result;

        }
        public IdentityResult Register(ApplicationUserIdentity user)
        {
            try
            {
                IdentityResult result = manager.Create(user, user.PasswordHash);
                return result;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
          
        }
        public IdentityResult AssignToRole(string userid, string rolename)
        {
            IdentityResult result = manager.AddToRole(userid, rolename);
            return result;

        }
        public ApplicationUserIdentity FindByName(string userName)
        {
            return manager.FindByName(userName);
        }

        public ApplicationUserIdentity GetById(string id)
        {
            ApplicationUserIdentity user = manager.FindById(id);
            return user;
        }

        public ApplicationUserIdentity GetByUserName(string name)
        {
            ApplicationUserIdentity user = manager.FindByName(name);
            return user;
        }


    }
}
