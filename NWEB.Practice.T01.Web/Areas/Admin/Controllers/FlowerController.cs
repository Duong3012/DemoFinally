using NWEB.Practice.T01.Web.Areas.Admin.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NWEB.Practice.T01.Web.Areas.Admin.ViewModel;
using System.IO;
using System.Web.WebPages;
using Microsoft.Ajax.Utilities;
using NWEB.Practice.T01.Core.Models;

namespace NWEB.Practice.T01.Web.Areas.Admin.Controllers
{
    public class FlowerController : Controller
    {
        // GET: Admin/Flower
        FlowerShopDbContext _db = new FlowerShopDbContext();
        public ActionResult Index()
        {
            return View(FlowerBusiness.GetAll());
        }

        // GET: Admin/Flower/Details/5
        public ActionResult Details(int id)
        {
            return View(FlowerBusiness.FindById(id));
        }

        public void LoadDropdownCategory()
        {
            var cate = CategoryBusiness.GetAll().ToList();
            // Tạo SelectList
            SelectList cateList = new SelectList(cate, "Id", "CategoryName");
            ViewBag.CategoryList = cateList;
        }
        public void LoadDropdownFlower()
        {
            var result = FlowerBusiness.GetAll().ToList();
            // Tạo SelectList
            SelectList flowerList = new SelectList(result, "Id", "FlowerName");
            // Set vào ViewBag
            ViewBag.FlowerList = flowerList;
        }
        public void LoadDropdownColor()
        {
            var result = ColorBusiness.GetAll().ToList();
            // Tạo SelectList
            SelectList colorList = new SelectList(result, "Id", "ColorName");
            // Set vào ViewBag
            ViewBag.ColorList = colorList;
        }

        // GET: Admin/Flower/Create
        public ActionResult Create()
        {
            LoadDropdownColor();
            LoadDropdownCategory();
            return View();
        }
        
        // POST: Admin/Flower/Create
        [HttpPost]
        public ActionResult Create(FlowerViewModel obj,HttpPostedFileBase image)
        {
            try
            {
                // TODO: Add insert logic here
                if (image != null)
                {
                    obj.Image = LoadImage(image);
                }
                FlowerBusiness.Create(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public string LoadImage(HttpPostedFileBase image)
        {
            if (image != null)
            {
                string fileName = Path.GetFileName(image.FileName);
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/ImageFlower"),fileName );
                image.SaveAs(path);
                return "/Areas/Admin/Content/ImageFlower/" + fileName;
            }

            return null;
        }
        // GET: Admin/Flower/Edit/5
        public ActionResult Edit(int id)
        {
            LoadDropdownCategory();
            LoadDropdownColor();
            return View(FlowerBusiness.FindById(id));
        }

        // POST: Admin/Flower/Edit/5
        [HttpPost]
        public ActionResult Edit(FlowerViewModel obj, HttpPostedFileBase image)
        {
            try
            {
                // TODO: Add update logic here
                if (image != null)
                {
                    obj.Image = LoadImage(image);
                }
                FlowerBusiness.Edit(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Flower/Delete/5
        public ActionResult Delete(int id)
        {

            FlowerBusiness.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult SaleOff()
        {
            List<CategoryViewModel> CountryList = CategoryBusiness.GetAll();
            ViewBag.CountryList = new SelectList(CountryList, "Id", "CategoryName");
            return View();
        }

        public JsonResult GetStateList(int CategoryId)
        {
            _db.Configuration.ProxyCreationEnabled = false;
            List<FlowerViewModel> StateList = FlowerBusiness.GetAll().Where(x => x.CategoryId == CategoryId).ToList();
            return Json(StateList, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaleOff([Bind(Exclude = "Id")] CategoryFlowerViewModel flower)
        {
            if (!ModelState.IsValid) return null;
            if (flower.FlowerName.IsEmpty() || flower.FlowerName.IsNullOrWhiteSpace())
            {
                var flowerY = FlowerBusiness.GetAll().Where(f => f.CategoryId == flower.CategoryId).ToList();
                foreach (var flowerViewModel in flowerY)
                {
                    flowerViewModel.SalePrice = flowerViewModel.Price * (1 - flower.SaleOff * 0.01m);
                    FlowerBusiness.Edit(flowerViewModel);
                }
                return RedirectToAction("Index");
            }

            var flowerX = FlowerBusiness.GetAll()
                .FirstOrDefault(f => f.CategoryId == flower.CategoryId && f.FlowerName == flower.FlowerName);
            if (flowerX == null) return HttpNotFound();
            flowerX.SalePrice = (flowerX.Price * (1 - flower.SaleOff * 0.01m));
            FlowerBusiness.Edit(flowerX);
            return RedirectToAction("Index");
        }

    }
}
