namespace AimyCompetition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Date : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exercises", "ExerciseDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercises", "ExerciseDate", c => c.DateTime(nullable: false));
        }
    }
}
