namespace JensTheLandmand_v6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fiddle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Products", "ProductDesc", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductDesc", c => c.String(maxLength: 100));
            AlterColumn("dbo.Products", "ProductName", c => c.String(maxLength: 60));
        }
    }
}
