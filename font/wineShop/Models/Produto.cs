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
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdProduto { get; set; }
        [Required]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string Fabricante { get; set; }
        public string Categoria { get; set; }
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
    }

}
