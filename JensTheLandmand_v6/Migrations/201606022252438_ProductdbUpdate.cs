namespace JensTheLandmand_v6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductdbUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductImage", c => c.Binary());
            DropColumn("dbo.Products", "ProductImage_ProductId");
            DropColumn("dbo.Products", "ProductImage_Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductImage_Image", c => c.Binary());
            AddColumn("dbo.Products", "ProductImage_ProductId", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "ProductImage");
        }
    }
}
