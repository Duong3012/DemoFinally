using NWEB.Practice.T01.Web.Areas.Admin.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Net;
using NWEB.Practice.T01.Web.Areas.Admin.ViewModel;

namespace NWEB.Practice.T01.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/ColorViewModels
        public ActionResult Index()
        {
            return View(CategoryBusiness.GetAll());
        }

        // GET: Admin/ColorViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var colorViewModel = ColorBusiness.FindById(id.Value);
            if (colorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(colorViewModel);
        }

        // GET: Admin/ColorViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ColorViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel obj)
        {
            if (ModelState.IsValid)
            {
                CategoryBusiness.Create(obj);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Admin/ColorViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CategoryViewModel categoryViewModel = CategoryBusiness.FindById(id.Value);
            if (categoryViewModel == null)
            {
                return HttpNotFound();
            }
            return View(categoryViewModel);
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryBusiness.Edit(obj);
                    return RedirectToAction("Index");
                }

                return null;
            }
            catch (Exception)
            {
                return View();
            }

        }
        // GET: Admin/ColorViewModels/Delete/5
        public ActionResult Delete(int id)
        {
            CategoryBusiness.Delete(id);
            return RedirectToAction("Index");

        }
    }
}