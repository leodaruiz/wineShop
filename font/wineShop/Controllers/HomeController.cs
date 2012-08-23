using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wineShop.Models;

namespace wineShop.Controllers
{
    public class HomeController : Controller
    {
        private ProdutosDBContext db = new ProdutosDBContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Sejam bem-vindos!";

            //return View();
            return View(db.Produtos.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
