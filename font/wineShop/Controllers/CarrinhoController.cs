using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wineShop.Models;

namespace wineShop.Controllers
{
    public class CarrinhoController : Controller
    {
        private MainContext db = new MainContext();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            var carrinho = CarrinhoHelper.GetCarrinho(this.HttpContext);

            return View(carrinho);
        }

        public ActionResult Add(int id)
        {
            var produto = db.Produtos.Single(p => p.IdProduto == id);

            // Add it to the shopping cart
            CarrinhoHelper.AddToCart(this.HttpContext, produto);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}