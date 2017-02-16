namespace Temple.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Guid(nullable: false),
                        MemberId = c.Guid(nullable: false),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        AddressLine1 = c.String(maxLength: 100),
                        AddressLine2 = c.String(maxLength: 100),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 2),
                        Zip = c.String(maxLength: 5),
                        FestivalId = c.Guid(nullable: false),
                        FestivalName = c.String(maxLength: 50),
                        OfferedServiceId = c.Guid(nullable: false),
                        OfferedServiceName = c.String(maxLength: 100),
                        SuggestedDonation = c.Decimal(nullable: false, precision: 14, scale: 2),
                        ActualDonation = c.Decimal(nullable: false, precision: 14, scale: 2),
                        ServiceDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.PurchaseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Purchases");
        }
    }
}
