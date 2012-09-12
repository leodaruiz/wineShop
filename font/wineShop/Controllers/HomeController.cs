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
        private MainContext db = new MainContext();

        public ActionResult Detalhes(int id)
        {
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Sejam bem-vindos!";
            Carrinho c = CarrinhoHelper.GetCarrinho(this.HttpContext);
            if (c.ItensCarrinho.Count > 0)
                ViewBag.MenuCarrinho = string.Format("Carrinho ({0})", c.ItensCarrinho.Count);

            return View(db.Produtos.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Sobre o sistema.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "contatos";

            return View();
        }
    }
}
