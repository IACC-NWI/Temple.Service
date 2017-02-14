namespace Temple.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Festivals",
                c => new
                    {
                        FestivalId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.FestivalId);
            
            CreateTable(
                "dbo.OfferedServices",
                c => new
                    {
                        ServiceId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        FestivalId = c.Guid(),
                        FestivalName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ServiceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OfferedServices");
            DropTable("dbo.Festivals");
        }
    }
}
