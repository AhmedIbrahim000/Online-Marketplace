using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;

namespace Final_Project.Controllers
{
    public class ProductController : Controller
    {
        //Settings
        private ApplicationDbContext _context;
        public ProductController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //End settings

        // GET: Product
        public ActionResult Index()
        {
            var product = _context.Products.Include(d => d.category).ToList();
            return View(product);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(d => d.category).SingleOrDefault(m => m.Id == id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var categories = _context.Categories.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in categories)
            {
                list.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.categories = list;
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //public ActionResult Create(Product product, HttpPostedFileBase ImageFile)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
        //        string extention = Path.GetExtension(ImageFile.FileName);
        //        fileName += extention;
        //        string path = Path.Combine(Server.MapPath("~/Images/"), fileName);
        //        ImageFile.SaveAs(fileName);
        //        product.ImagePath = "~/Images/" + fileName;
        //        _context.Products.Add(product);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _context.Products.Include(d => d.category).SingleOrDefault(m => m.Id == id);
            var categories = _context.Categories.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in categories)
            {
                list.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.categories = list;
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                // TODO: Add update logic here
                var productDb = _context.Products.Include(d => d.category).SingleOrDefault(c => c.Id == id);
                productDb.Name = product.Name;
                productDb.Price = product.Price;
                productDb.Quantity = product.Quantity;
                productDb.categoryId = product.categoryId;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //public ActionResult Edit(int id, Product product, HttpPostedFileBase ImageFile)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
        //        var productDb = _context.Products.Include(d => d.category).SingleOrDefault(c => c.Id == id);

        //        string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
        //        string extention = Path.GetExtension(ImageFile.FileName);
        //        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
        //        product.ImagePath = "~/Images/" + fileName;
        //        string path = Path.Combine(Server.MapPath("~/Images/"), fileName);
        //        ImageFile.SaveAs(fileName);

        //        productDb.Name = product.Name;
        //        productDb.Price = product.Price;
        //        productDb.Quantity = product.Quantity;
        //        productDb.ImagePath = product.ImagePath;
        //        productDb.categoryId = product.categoryId;
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _context.Products.Include(d => d.category).SingleOrDefault(m => m.Id == id);
            var categories = _context.Categories.ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in categories)
            {
                list.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.categories = list;
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                // TODO: Add delete logic here
                var productDb = _context.Products.Include(d => d.category).SingleOrDefault(c => c.Id == id);
                _context.Products.Remove(productDb);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
