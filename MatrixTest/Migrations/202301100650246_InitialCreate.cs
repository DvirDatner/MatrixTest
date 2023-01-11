namespace MatrixTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Ability = c.Int(nullable: false),
                        GuidId = c.Int(nullable: false),
                        StartedTrainDate = c.DateTime(nullable: false),
                        SuitColor = c.String(),
                        StartingPower = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentPower = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuidId = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trainers");
            DropTable("dbo.Heroes");
        }
    }
}
