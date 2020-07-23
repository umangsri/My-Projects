using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetsmartzOnlineStore.Services;
using NetsmartzOnlineStore.Models;

namespace NetsmartzOnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _service;
        public ProductController()
        {
            _service = new ProductService();
        }
        // GET: Product
        public ActionResult Index(int id)
        {
            var productLst = _service.GetProductList(id);
            ViewBag.CategoryID = id;
            return View(productLst);
        }
        public ActionResult Create(int catID)
        {
            ProductModels obj = new ProductModels();
            obj.CategoryID_FK = catID;
            return View(obj);
        }
        [HttpPost]
        public ActionResult Create(ProductModels obj)
        {
            _service.CreateProduct(obj);
            return RedirectToAction("Index", new { id = obj.CategoryID_FK});
        }
        public ActionResult Edit(int id, int catID)
        {
            ProductModels obj = _service.GetProductByID(id, catID);
            return View("Create", obj);
        }
        [HttpPost]
        public ActionResult Edit(ProductModels obj)
        {
            _service.UpdateProduct(obj);
            return RedirectToAction("Index", new { id = obj.CategoryID_FK });
        }
        public ActionResult Delete(int id, int catID)
        {
            _service.DeleteProduct(id, catID);
            return RedirectToAction("Index", new { id = catID });
        }
    }
}