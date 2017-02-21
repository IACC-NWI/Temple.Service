namespace Temple.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDescriptionLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Festivals", "Description", c => c.String(maxLength: 4000));
            AlterColumn("dbo.OfferedServices", "Description", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OfferedServices", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.Festivals", "Description", c => c.String(maxLength: 500));
        }
    }
}
