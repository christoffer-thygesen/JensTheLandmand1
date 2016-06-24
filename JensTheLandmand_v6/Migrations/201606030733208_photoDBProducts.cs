namespace JensTheLandmand_v6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photoDBProducts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductImage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductImage", c => c.Binary());
        }
    }
}
