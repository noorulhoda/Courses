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
    public class CommentController : Controller
    {
        CommentAppServices commentAppService = new CommentAppServices();

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(CommentVM newComment)
        {
            if (ModelState.IsValid == false)
                return View(newComment);
            //if (newComment.ImageFile != null)
            //{
            //    string filename = Path.GetFileName(newComment.ImageFile.FileName);
            //    newComment.image = filename;
            //    filename = Path.Combine(Server.MapPath("Content/") + filename);
            //    newComment.ImageFile.SaveAs(filename);
            //}
            commentAppService.SaveNewComment(newComment);
            return RedirectToAction("Index");
        }



        // GET: 
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<CommentVM> s = commentAppService.GetAllComment();
            return View(s);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentVM comment = commentAppService.GetVMById(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }


        // GET: Comments/Edit/5
        public ActionResult Edit(int id)
        {
            CommentVM s = commentAppService.GetVMById(id);
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommentVM commentVM)
        {
            commentVM.ID = id;

            if (ModelState.IsValid)
            {
                CommentVM c = commentAppService.GetVMById(id);
                return View(c);
            }

            return View(commentVM);


        }

        //// GET: Comments/Delete/5
        //[HttpGet]
        //public ActionResult Delete()
        //{
        //    return View();
        //}


        // [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            commentAppService.DeleteComment(id);
            return RedirectToAction("Index");
        }


    }
}
