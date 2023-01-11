namespace MatrixTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFullNameToTrainersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainers", "FullName");
        }
    }
}
