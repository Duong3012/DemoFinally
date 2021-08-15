using NWEB.Practice.T01.Web.Areas.Admin.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NWEB.Practice.T01.Web.Areas.Admin.ViewModel;

namespace NWEB.Practice.T01.Web.Areas.Admin.Controllers
{
    public class FlowerController : Controller
    {
        // GET: Admin/Flower
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
            SelectList cateList= new SelectList(cate, "Id", "CategoryName");
            // Set vào ViewBag
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
        public ActionResult SaleOff()
        {
            LoadDropdownCategory();
            LoadDropdownFlower();
            return View();
        }

        [HttpPost]
        public ActionResult SaleOff(string categoryName, string flowerName, decimal saleOff)
        {
            
                var flowerList = FlowerBusiness.GetByFlowerAndCategoryName(categoryName, flowerName);
                if (flowerList != null)
                {
                    foreach (var flower in flowerList)
                    {
                        if (flower.SalePrice > 0)
                        {
                            flower.SalePrice = flower.Price * (1 - saleOff * 0.01m);
                        }
                        FlowerBusiness.Edit(flower);
                    }
                    return RedirectToAction("Index");
                }

                return HttpNotFound();
        }
        // POST: Admin/Flower/Create
        [HttpPost]
        public ActionResult Create(FlowerViewModel obj)
        {
            try
            {
                // TODO: Add insert logic here
                FlowerBusiness.Create(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
        public ActionResult Edit(FlowerViewModel obj)
        {
            try
            {
                // TODO: Add update logic here
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

    }
}
