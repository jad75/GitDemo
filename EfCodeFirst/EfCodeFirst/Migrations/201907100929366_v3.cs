namespace EfCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Employees", newName: "Mitarbeiter");
            AddColumn("dbo.Mitarbeiter", "Kündigungsdatum", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Mitarbeiter", "Kündigungsdatum");
            RenameTable(name: "dbo.Mitarbeiter", newName: "Employees");
        }
    }
}
