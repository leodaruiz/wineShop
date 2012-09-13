using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using wineShop.Models;
using System.Data.Entity.Validation;

namespace wineShop.Tests
{
    [TestFixture]
    public class DbContextTest
    {

        [Test]
        public void IncluirProdutoOK()
        {
            MainContext db = new MainContext();

            db.Produtos.Add(new Produto { Nome = "Carmenere", Descricao = "Carmenere - Concha Y Toro", Fabricante = "Concha Y Toro", Preco = 21.75m });
            db.SaveChanges();

            Produto carmenere = db.Produtos.FirstOrDefault(p => p.Nome == "Carmenere");
            Assert.IsNotNull(carmenere, "Produto Carmenere não encontrado.");
            Assert.AreEqual(21.75m, carmenere.Preco, "Preço deveria ser 21.75");
        }

        [Test]
        public void IncluirProdutoSemNome()
        {
            bool erroValidacao = false;
            string msgErro = "";
            MainContext db = new MainContext();
            Produto p = new Produto();
            db.Produtos.Add(p);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                msgErro = ex.EntityValidationErrors.FirstOrDefault().ValidationErrors.FirstOrDefault().ErrorMessage;
                erroValidacao = true;
            }
            Assert.IsTrue(erroValidacao, "Erro de validação, Nome Obrigatório");
            Assert.AreEqual("Nome Obrigatório", msgErro);
        }
    }
}