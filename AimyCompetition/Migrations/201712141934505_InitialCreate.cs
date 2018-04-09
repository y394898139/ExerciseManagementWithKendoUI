namespace AimyCompetition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExerciseName = c.String(maxLength: 100),
                        ExerciseDate = c.DateTime(nullable: false),
                        DurationTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Exercises");
        }
    }
}
