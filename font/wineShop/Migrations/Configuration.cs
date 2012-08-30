namespace wineShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using wineShop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<wineShop.Models.MainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(wineShop.Models.MainContext context)
        {
            context.Produtos.AddOrUpdate(
                new Produto { Nome = "Carmenere", Descricao = "Carmenere - Concha Y Toro", Fabricante = "Concha Y Toro", Preco = 21.75m },
                new Produto { Nome = "Merlot", Descricao = "Merlot - Concha Y Toro", Fabricante = "Concha Y Toro", Preco = 19.90m },
                new Produto { Nome = "Cabernet Sauvignon", Descricao = "Cabernet Sauvignon - Concha Y Toro", Fabricante = "Concha Y Toro", Preco = 29.90m }
            );
        }
    }
}
