namespace JensTheLandmand_v6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileDBupdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ProductImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductImage", c => c.Int(nullable: false));
        }
    }
}
