using BL.Bases;
using BL.ViewModels;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
      public class AccountAppServices : BaseAppServices
    {
        //Login
        public ApplicationUserIdentity Find(string name, string password)
        {
            return TheUnitOfWork.Account.Find(name, password);
        }

        public bool IsExisted(string name, string password)
        {
            ApplicationUserIdentity user= TheUnitOfWork.Account.Find(name, password);
            if (user != null) return true;
            return false;
        }

        public IdentityResult Register(RegisterVM user)
        {
            ApplicationUserIdentity identityUser =
                Mapper.Map<RegisterVM, ApplicationUserIdentity>(user);
            return TheUnitOfWork.Account.Register(identityUser);

        }
      
        public bool SignIn(LoginVM user, IAuthenticationManager owinManager)
        {
            try
            {
                SignInManager<ApplicationUserIdentity, string> signinmanager =
                            new SignInManager<ApplicationUserIdentity, string>(
                                new ApplicationUserManager(), owinManager
                                );

                ApplicationUserIdentity identityUser = Find(user.UserName, user.PasswordHash);
                signinmanager.SignIn(identityUser, true, true);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool AssignToRole(RegisterVM uservm)
        {
            try
            {
               
                ApplicationUserIdentity user = TheUnitOfWork.Account.FindByName(uservm.UserName);
                
                if (uservm.userType == UserType.Teacher)
                {
                    TheUnitOfWork.Account.AssignToRole(user.Id, "Teacher");
                    Teacher teacher = new Teacher()
                    {
                        user = user,
                        ID = user.Id,
                        firstName = uservm.firstName,
                        lastName = uservm.lastName,
                        gender = uservm.gender.ToString(),
                        age = uservm.age,
                        image = "defaultProfile.jpg"
                    };
                    user.teacher = teacher;
                    TheUnitOfWork.Teacher.InsertTeacher(teacher);
                    TheUnitOfWork.Commit();
                }
               
                
                else if (uservm.userType == UserType.Student)
                {
                    TheUnitOfWork.Account.AssignToRole(user.Id, "Student");
                    Student student = new Student()
                    {
                        user= user,
                        ID = user.Id,
                        firstName = uservm.firstName,
                        lastName = uservm.lastName,
                        gender = uservm.gender.ToString(),
                        age = uservm.age,
                        image = "defaultProfile.jpg"
                    };
                    user.student = student;
                    TheUnitOfWork.Student.InsertStudent(student);
                    TheUnitOfWork.Commit();
                   
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetNameByID(string id)
        {
            return TheUnitOfWork.Account.GetById(id).UserName;
        }

        public string GetIDByName(string name)
        {
            return TheUnitOfWork.Account.FindByName(name).Id;
        }
    }
}
