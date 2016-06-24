namespace JensTheLandmand_v6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class piechartdetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChartProductDetailsViewModels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ChartProductDetailsViewModels");
        }
    }
}
