using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace wineShop.Models
{
    public class MainContext : DbContext
    {
        public MainContext() : base("DefaultConnection") { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
    }
}