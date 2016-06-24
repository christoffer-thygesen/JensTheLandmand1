namespace JensTheLandmand_v6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productVM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductViewModels", "imgFiles_FileId", "dbo.Files");
            DropForeignKey("dbo.ProductViewModels", "Products_ProductID", "dbo.Products");
            DropIndex("dbo.ProductViewModels", new[] { "imgFiles_FileId" });
            DropIndex("dbo.ProductViewModels", new[] { "Products_ProductID" });
            DropColumn("dbo.ProductViewModels", "imgFiles_FileId");
            DropColumn("dbo.ProductViewModels", "Products_ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductViewModels", "Products_ProductID", c => c.Int());
            AddColumn("dbo.ProductViewModels", "imgFiles_FileId", c => c.Int());
            CreateIndex("dbo.ProductViewModels", "Products_ProductID");
            CreateIndex("dbo.ProductViewModels", "imgFiles_FileId");
            AddForeignKey("dbo.ProductViewModels", "Products_ProductID", "dbo.Products", "ProductID");
            AddForeignKey("dbo.ProductViewModels", "imgFiles_FileId", "dbo.Files", "FileId");
        }
    }
}
