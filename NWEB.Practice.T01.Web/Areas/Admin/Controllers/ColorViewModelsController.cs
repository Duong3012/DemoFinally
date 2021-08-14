using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NWEB.Practice.T01.Core.Models;
using NWEB.Practice.T01.Web.Areas.Admin.Business;
using NWEB.Practice.T01.Web.Areas.Admin.ViewModel;

namespace NWEB.Practice.T01.Web.Areas.Admin.Controllers
{
    public class ColorViewModelsController : Controller
    {
        
        // GET: Admin/ColorViewModels
        public ActionResult Index()
        {
            return View(ColorBusiness.GetAll());
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
        public ActionResult Create([Bind(Include = "Id,ColorName")] ColorViewModel colorViewModel)
        {
            if (ModelState.IsValid)
            {
                ColorBusiness.Create(colorViewModel);
                return RedirectToAction("Index");
            }

            return View(colorViewModel);
        }

        // GET: Admin/ColorViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ColorViewModel colorViewModel = ColorBusiness.FindById(id.Value);
            if (colorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(colorViewModel);
        }
        [HttpPost]
        public ActionResult Edit(ColorViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ColorBusiness.Edit(obj);
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
            ColorBusiness.Delete(id);
            return RedirectToAction("Index");

        }

    }
}
