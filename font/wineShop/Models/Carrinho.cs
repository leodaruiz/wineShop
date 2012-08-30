using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Collections.Generic;

namespace wineShop.Models
{
    public class ItemCarrinho
    {
        public int IdCarrinho { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public System.DateTime DataInclusao { get; set; }
    }

    public static class CarrinhoHelper
    {
        public static Carrinho GetCarrinho(HttpContextBase context)
        {
            Carrinho carrinho;
            if (context.Session["Carrinho"] != null)
                carrinho = (Carrinho)context.Session["Carrinho"];
            else
                carrinho = new Carrinho();

            return carrinho;
        }

        public static void AddToCart(HttpContextBase context, Produto produto)
        {
            Carrinho carrinho;
            if (context.Session["Carrinho"] != null)
                carrinho = (Carrinho)context.Session["Carrinho"];
            else
                carrinho = new Carrinho();

            // Get the matching cart and album instances
            var itemCarrinho = carrinho.ItensCarrinho.SingleOrDefault(c => c.IdProduto == produto.IdProduto);

            if (itemCarrinho == null)
            {
                // Create a new cart item if no cart item exists
                itemCarrinho = new ItemCarrinho
                {
                    IdProduto = produto.IdProduto,
                    Quantidade = 1,
                    DataInclusao = DateTime.Now
                };

                carrinho.ItensCarrinho.Add(itemCarrinho);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                itemCarrinho.Quantidade++;
            }

            // Save changes
            context.Session.Add("Carrinho", carrinho);
        }
    }

    public class Carrinho
    {
        public List<ItemCarrinho> ItensCarrinho { get; set; }

        public Carrinho()
        {
            this.ItensCarrinho = new List<ItemCarrinho>();
        }
    }
}