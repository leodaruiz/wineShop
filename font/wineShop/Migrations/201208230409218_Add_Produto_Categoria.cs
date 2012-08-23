namespace wineShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Produto_Categoria : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produto", "Categoria", c => c.String());
            AlterColumn("dbo.Produto", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "Nome", c => c.String());
            DropColumn("dbo.Produto", "Categoria");
        }
    }
}
