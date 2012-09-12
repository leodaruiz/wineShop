namespace wineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        IdProduto = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                        Fabricante = c.String(),
                        Categoria = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdProduto);
            
            CreateTable(
                "dbo.Carrinhoes",
                c => new
                    {
                        IdCarrinho = c.Int(nullable: false, identity: true),
                        NomeComprador = c.String(),
                    })
                .PrimaryKey(t => t.IdCarrinho);
            
            CreateTable(
                "dbo.ItemCarrinhoes",
                c => new
                    {
                        IdItemCarrinho = c.Int(nullable: false, identity: true),
                        IdProduto = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        DataInclusao = c.DateTime(nullable: false),
                        Carrinho_IdCarrinho = c.Int(),
                    })
                .PrimaryKey(t => t.IdItemCarrinho)
                .ForeignKey("dbo.Carrinhoes", t => t.Carrinho_IdCarrinho)
                .Index(t => t.Carrinho_IdCarrinho);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ItemCarrinhoes", new[] { "Carrinho_IdCarrinho" });
            DropForeignKey("dbo.ItemCarrinhoes", "Carrinho_IdCarrinho", "dbo.Carrinhoes");
            DropTable("dbo.ItemCarrinhoes");
            DropTable("dbo.Carrinhoes");
            DropTable("dbo.Produto");
        }
    }
}
