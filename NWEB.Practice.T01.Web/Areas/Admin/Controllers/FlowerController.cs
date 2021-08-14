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

        public void LoadDropdown()
        {
            var result = FlowerBusiness.GetAll().ToList();
            var cate = CategoryBusiness.GetAll().ToList();

            // Tạo SelectList
            SelectList flowerList = new SelectList(result, "CategoryId", "FlowerName");
            SelectList cateList= new SelectList(cate, "Id", "CategoryName");
            // Set vào ViewBag
            ViewBag.FlowerList = flowerList;
            ViewBag.CategoryList = cateList;
        }

        // GET: Admin/Flower/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CreateSaleOff()
        {
            LoadDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult CreateSaleOff(SaleOfViewModel obj)
        {
            try
            {
                // TODO: Add insert logic here
                FlowerBusiness.CreateSaleOff(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
