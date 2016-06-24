namespace JensTheLandmand_v6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Links", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Links", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Products", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Links", "ApplicationUser_Id");
            DropColumn("dbo.Products", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Links", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Products", "ApplicationUser_Id");
            CreateIndex("dbo.Links", "ApplicationUser_Id");
            AddForeignKey("dbo.Products", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Links", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
