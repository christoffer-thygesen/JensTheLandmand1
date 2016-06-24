namespace JensTheLandmand_v6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class linksdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        LinksID = c.Int(nullable: false, identity: true),
                        LinkURL = c.String(),
                        LinkDesc = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LinksID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Links", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Links");
        }
    }
}
