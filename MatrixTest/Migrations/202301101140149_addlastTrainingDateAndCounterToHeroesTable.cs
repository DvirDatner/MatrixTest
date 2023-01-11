namespace MatrixTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlastTrainingDateAndCounterToHeroesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "LastTrainingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Heroes", "TrainingCounter", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Heroes", "TrainingCounter");
            DropColumn("dbo.Heroes", "LastTrainingDate");
        }
    }
}
