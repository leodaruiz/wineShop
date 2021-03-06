﻿using System;
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
            ViewBag.ProdutosCarrinho = getProdutos(carrinho);
            return View(carrinho);
        }

        private List<Produto> getProdutos(Carrinho carrinho)
        {
            List<Produto> produtos = new List<Produto>();
            foreach (var item in carrinho.ItensCarrinho)
            {
                Produto produto = db.Produtos.FirstOrDefault(p => p.IdProduto == item.IdProduto);
                produtos.Add(produto);
            }
            return produtos;
        }

        public ActionResult Add(int id)
        {
            var produto = db.Produtos.Single(p => p.IdProduto == id);

            // Add it to the shopping cart
            CarrinhoHelper.AddToCart(this.HttpContext, produto);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Index(Carrinho c)
        {
            var carrinho = CarrinhoHelper.GetCarrinho(this.HttpContext);
            ViewBag.ProdutosCarrinho = getProdutos(carrinho);
            carrinho.NomeComprador = c.NomeComprador;
            if (ModelState.IsValid)
            {
                db.Carrinhos.Add(carrinho);
                db.SaveChanges();
                CarrinhoHelper.LimparCarrinho(this.HttpContext);

                ViewBag.Sucesso = true;
                
            }
            return View(carrinho);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}