using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BL.AppServices;
using BL.ViewModels;
using Web.Data;

namespace Web.Controllers
{
    public class ClassController : Controller
    {
        ClassAppServices classsAppService = new ClassAppServices();

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(ClassVM newClass)
        {
            if (ModelState.IsValid == false)
                return View(newClass);
            //if (newClass.ImageFile != null)
            //{
            //    string filename = Path.GetFileName(newClass.ImageFile.FileName);
            //    newClass.image = filename;
            //    filename = Path.Combine(Server.MapPath("Content/") + filename);
            //    newClass.ImageFile.SaveAs(filename);
            //}
            classsAppService.SaveNewClass(newClass);  
            return RedirectToAction("Index");
        }



        // GET: 
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<ClassVM> s = classsAppService.GetAllClass();
            return View(s);
        }

        // GET: Classs/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassVM classs = classsAppService.GetVMById(id);
            if (classs == null)
            {
                return HttpNotFound();
            }
            return View(classs);
        }


        // GET: Classs/Edit/5
        public ActionResult Edit(int id)
        {
            ClassVM s = classsAppService.GetVMById(id);
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClassVM classsVM)
        {
            classsVM.ID = id;

            if (ModelState.IsValid)
            {
                ClassVM c = classsAppService.GetVMById(id);
                return View(c);
            }

            return View(classsVM);


        }

        //// GET: Classs/Delete/5
        //[HttpGet]
        //public ActionResult Delete()
        //{
        //    return View();
        //}

     
        // [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            classsAppService.DeleteClass(id);
            return RedirectToAction("Index");
        }


    }
}
