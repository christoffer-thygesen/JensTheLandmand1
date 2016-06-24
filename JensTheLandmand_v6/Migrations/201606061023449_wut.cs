namespace JensTheLandmand_v6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductViewModels", "imgFiles_FileId", c => c.Int());
            AddColumn("dbo.ProductViewModels", "Products_ProductID", c => c.Int());
            CreateIndex("dbo.ProductViewModels", "imgFiles_FileId");
            CreateIndex("dbo.ProductViewModels", "Products_ProductID");
            AddForeignKey("dbo.ProductViewModels", "imgFiles_FileId", "dbo.Files", "FileId");
            AddForeignKey("dbo.ProductViewModels", "Products_ProductID", "dbo.Products", "ProductID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductViewModels", "Products_ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductViewModels", "imgFiles_FileId", "dbo.Files");
            DropIndex("dbo.ProductViewModels", new[] { "Products_ProductID" });
            DropIndex("dbo.ProductViewModels", new[] { "imgFiles_FileId" });
            DropColumn("dbo.ProductViewModels", "Products_ProductID");
            DropColumn("dbo.ProductViewModels", "imgFiles_FileId");
        }
    }
}
