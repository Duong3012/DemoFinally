using NWEB.Practice.T01.DataAccessLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NWEB.Practice.T01.Web.Controllers
{
    public class FlowersController : Controller
    {
        private FlowerService flower = new FlowerService();
        // GET: Flowers
        public ActionResult Index()
        {
            return View(flower.GetAll());
        }

        public ActionResult GetAllFlowerById(int categoryId)
        {
            var resutl = flower.GetAll().Where(x => x.CategoryId == categoryId).ToList();
            return View(resutl);
        }
    }
}