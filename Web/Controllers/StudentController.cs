using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL.AppServices;
using BL.ViewModels;
using Web.Data;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        StudentAppServices studentAppService = new StudentAppServices();
        // GET: 
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<StudentVM> s=studentAppService.GetAllStudent();
            return View(s);
        }

        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentVM student = studentAppService.GetVMById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

    
        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            StudentVM s = studentAppService.GetVMById(id);
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id,StudentVM studentVM)
        {
            studentVM.ID = id;
           
            if (ModelState.IsValid)
            {
                studentAppService.UpdateStudent(studentVM);
                return View();
            }

            return View(studentVM);


        }

        //// GET: Students/Delete/5
        //[HttpGet]
        //public ActionResult Delete()
        //{
        //    return View();
        //}

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            studentAppService.DeleteStudent(id);
            return RedirectToAction("Index");
        }


    }
}
