using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace wineShop.Models
{
    public class ProdutosDBContext : DbContext
    {
        public ProdutosDBContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Produto> Produtos { get; set; }
    }

    [Table("Produto")]
    public class Produto
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdProduto { get; set; }
        [Required]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Fabricante { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
    }

}
