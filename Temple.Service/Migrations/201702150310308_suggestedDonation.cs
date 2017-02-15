namespace Temple.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class suggestedDonation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OfferedServices", "SuggestedDonation", c => c.Decimal(nullable: false, precision: 14, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfferedServices", "SuggestedDonation");
        }
    }
}
