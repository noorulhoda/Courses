using BL.AppServices;
using BL.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        CategoryAppServices categoryAppService = new CategoryAppServices();
        public ActionResult Index(int? PageNum)
        {
            return View(categoryAppService.GetAllCategory().ToPagedList(PageNum ?? 1, 5));
        }
        [HttpPost]
        public ActionResult Index(string search, int? PageNum)
        {
            var list = categoryAppService.GetAllCategory();
            var list2 = new List<CategoryVM>();
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

        public ActionResult GetCategory(int id)
        {
            return View(categoryAppService.GetCategory(id));
        }
        
        public ActionResult AddNewCategory() => View();

        [HttpPost]
        public ActionResult AddNewCategory(CategoryVM newCategory)
        {
            if (ModelState.IsValid==false)
                return View(newCategory);


            //string filename = Path.GetFileName(newCategory.ImageFile.FileName);
            //filename = Path.Combine(Server.MapPath("/Content/"), filename);
            //newCategory.image = filename;
            //newCategory.ImageFile.SaveAs(filename);

            HttpPostedFileBase file = newCategory.ImageFile;
            if (file != null && file.ContentLength > 0)
            {
                var f = System.IO.Path.GetFileName(file.FileName);//file is null
                file.SaveAs(Server.MapPath("~/Content/" + f));
                newCategory.image = f;
            }

            categoryAppService.SaveNewCategory(newCategory);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateCategory(int id)
        {
            CategoryVM category = categoryAppService.GetCategory(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult UpdateCategory(string option,CategoryVM category, int id)
        {
            category.ID = id;


            if (option == "Checked")
            {
                if (ModelState.IsValid == true)
                {
                    string filename = Path.GetFileName(category.ImageFile.FileName);
                    category.image = filename;
                    filename = Path.Combine(Server.MapPath("~/Content/") + filename);
                    category.ImageFile.SaveAs(filename);
                    categoryAppService.UpdateCategory(category);
                    return RedirectToAction("Index");
                }
            }
            else 
            {
                if (ModelState.IsValid == true)
                {
                    categoryAppService.UpdateCategory(category);
                    return RedirectToAction("Index");
                }
            }
                

            return View(category);
        }
       
        public ActionResult DeleteCategory(int id)
        {
            return View(categoryAppService.GetCategory(id));
        }
        [HttpPost]
        public ActionResult DeleteCategory(int id, CategoryVM deleteCategory)
        {
            categoryAppService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}