using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetsmartzOnlineStore.Services;
using NetsmartzOnlineStore.Models;

namespace NetsmartzOnlineStore.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _service;
        public CategoryController()
        {
            _service = new CategoryService();
        }
        // GET: Category
        public ActionResult Index()
        {
            var catLst = _service.GetCategoryList();
            return View(catLst);
        }
        public ActionResult Create()
        {
            CategoryModels obj = new CategoryModels();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Create(CategoryModels obj)
        {
            _service.CreateCategory(obj);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            CategoryModels obj = _service.GetCategoryByID(id);
            return View("Create", obj);
        }
        [HttpPost]
        public ActionResult Edit(CategoryModels obj)
        {
            _service.UpdateCategory(obj);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _service.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}