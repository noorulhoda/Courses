using BL.AppServices;
using BL.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        AccountAppServices accountAppService = new AccountAppServices();
        StudentAppServices studentAppService = new StudentAppServices();
        TeacherAppServices teacherAppService = new TeacherAppServices();
        // GET: Account


        public ActionResult Register() => View();

        [HttpPost]
        public ActionResult Register(RegisterVM user)
        {
            if (ModelState.IsValid == false)
            {
                return View(user);
            }
            IdentityResult result = accountAppService.Register(user);
            if (result.Succeeded)
            {
                IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
                accountAppService.SignIn(user, owinMAnager);
                accountAppService.AssignToRole(user);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault());
                return View(user);
            }
        }
        
        
        
        
        
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(LoginVM user)
        {
            if (ModelState.IsValid == false)
            {
                return View(user);
            }
            bool isExisted = accountAppService.IsExisted(user.UserName, user.PasswordHash);

            if (isExisted)
            {
                IAuthenticationManager owinManager = HttpContext.GetOwinContext().Authentication;
                accountAppService.SignIn(user, owinManager);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Not Valid Username & Password");
                return View(user);
            }

        }
       
        
        
        
        
        
        
        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager owinMAnager = HttpContext.GetOwinContext().Authentication;
            owinMAnager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index","Home");
        }

    }
}