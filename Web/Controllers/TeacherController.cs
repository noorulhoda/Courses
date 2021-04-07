using BL.AppServices;
using BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    
    public class TeacherController : Controller
    {
        TeacherAppServices teacherAppService = new TeacherAppServices();
        // GET: Order
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            return View(teacherAppService.GetAllTeacher());
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherVM teacher = teacherAppService.GetVMById(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }


        // GET: Teachers/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, TeacherVM teacherVM)
        {
            teacherVM.ID = id;
            if (ModelState.IsValid)
            {
                teacherAppService.UpdateTeacher(teacherVM);
                return View();
            }
            return View(teacherVM);
        }


        [HttpPost]
        public ActionResult Delete(string id)
        {
            teacherAppService.DeleteTeacher(id);
            return RedirectToAction("Index");
        }

    }

}