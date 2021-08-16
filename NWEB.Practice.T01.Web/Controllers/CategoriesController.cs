using NWEB.Practice.T01.DataAccessLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NWEB.Practice.T01.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryService _cateService = new CategoryService();
        // GET: Category
        public ActionResult Index()
        {
            return View(_cateService.GetAll().ToList());
        }

        public ActionResult GetAllCategory()
        {
            var result = _cateService.GetAll().ToList();
            return PartialView("_PartialCategory", result);
        }
        public ActionResult Details(int id)
        {
            return View(_cateService.FindById(id));
        }

        //public ActionResult GetAllFlowerById()
        //{
        //    var resutl  = _cateService.GetAll().Where(x=>x.Flowers).tol
        //    return PartialView("ListFlowerByCategory",resutl);
        //}
    }
}