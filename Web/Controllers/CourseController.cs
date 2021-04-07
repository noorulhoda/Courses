using BL.AppServices;
using BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.IO;

namespace Web.Controllers
{
    public class CourseController : Controller
    {
        CourseAppServices courseAppService = new CourseAppServices();
        CategoryAppServices categoryAppService = new CategoryAppServices();
        CommentAppServices commentAppService = new CommentAppServices();
        AccountAppServices accountAppServices = new AccountAppServices();
        StudentAppServices studentAppServices = new StudentAppServices();
        public ActionResult Index(int? PageNum)
        {
            return View(courseAppService.GetAllCourse().ToPagedList(PageNum ?? 1, 5));
        }
        [HttpPost]
        public ActionResult Index(string search, int? PageNum)
        {
            var list = courseAppService.GetAllCourse();
            var list2 = new List<CourseVM>();
            foreach (var item in list)
            {
                if (!String.IsNullOrEmpty(search))
                {
                    if (item.title.Contains(search))
                    {
                        list2.Add(item);
                    }
                }
            }
            return View(list2.ToPagedList(PageNum ?? 1, 5));
        }

        public ActionResult GetCourse(int id)
        {
            List<CommentVM> c = commentAppService.GetAllComment().ToList();
            ViewData["comments"] = c;
            return View(courseAppService.GetCourse(id));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult IndexCourse()
        {
            return PartialView("_IndexCourse", courseAppService.GetAllCourse());
        }
        [Authorize(Roles = "Admin")]
        public ActionResult AddNewCourse()
        {
            List<CategoryVM> cat = categoryAppService.GetAllCategory().ToList();
            ViewData["cat"] = cat;
            return View();
        }

        [HttpPost]
        public ActionResult AddNewCourse(CourseVM newCourse)
        {
            if (ModelState.IsValid == false)
                return View(newCourse);

            string filename = Path.GetFileName(newCourse.ImageFile.FileName);
            newCourse.image = filename;
            filename = Path.Combine(Server.MapPath("~/Content/") + filename);
            newCourse.ImageFile.SaveAs(filename);
            courseAppService.SaveNewCourse(newCourse);
            return RedirectToAction("IndexCourse");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateCourse(int id)
        {
            CourseVM course = courseAppService.GetCourse(id);
            return View(course);
        }
        [HttpPost]
        public ActionResult UpdateCourse(string option, CourseVM course, int id)
        {
            course.ID = id;


            if (option == "Checked")
            {
                if (ModelState.IsValid == true)
                {
                    string filename = Path.GetFileName(course.ImageFile.FileName);
                    course.image = filename;
                    filename = Path.Combine(Server.MapPath("~/Content/") + filename);
                    course.ImageFile.SaveAs(filename);
                    courseAppService.UpdateCourse(course);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (ModelState.IsValid == true)
                {
                    courseAppService.UpdateCourse(course);
                    return RedirectToAction("Index");
                }
            }


            return View(course);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteCourse(int id)
        {
            return View(courseAppService.GetCourse(id));
        }
        [HttpPost]
        public ActionResult DeleteCourse(int id, CourseVM deleteCourse)
        {
            courseAppService.DeleteCourse(id);
            return RedirectToAction("IndexCourse");
        }


        public ActionResult Enroll(int id)
        {
           
            return View(courseAppService.GetCourse(id));
        }
        public ActionResult EnrollStudent(int id,string studentName)
        {
          
            string studentID = accountAppServices.GetIDByName(studentName);
            StudentVM s=studentAppServices.GetStudent(studentID);
            courseAppService.EnrollStudent(id, s);   
            return RedirectToAction("Index", "Class");
        }

    }
}