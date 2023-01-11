namespace MatrixTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTrainingCounterToHeroesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Heroes", "Trainer_Id", c => c.Int());
            CreateIndex("dbo.Heroes", "Trainer_Id");
            AddForeignKey("dbo.Heroes", "Trainer_Id", "dbo.Trainers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Heroes", "Trainer_Id", "dbo.Trainers");
            DropIndex("dbo.Heroes", new[] { "Trainer_Id" });
            DropColumn("dbo.Heroes", "Trainer_Id");
        }
    }
}
