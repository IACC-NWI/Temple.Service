namespace Temple.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Donors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        DonorId = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.DonorId);
            
            AddColumn("dbo.Purchases", "DonorId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Purchases", "MemberId", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Purchases", "MemberId", c => c.Guid(nullable: false));
            DropColumn("dbo.Purchases", "DonorId");
            DropTable("dbo.Donors");
        }
    }
}
