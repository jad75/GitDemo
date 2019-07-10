namespace EfCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Job = c.String(name: "Job ", maxLength: 98),
                        Name = c.String(nullable: false, maxLength: 67),
                        GebDatum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kunde",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KdNummer = c.String(),
                        Name = c.String(),
                        GebDatum = c.DateTime(nullable: false),
                        Mitarbeiter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Mitarbeiter_Id)
                .Index(t => t.Mitarbeiter_Id);
            
            CreateTable(
                "dbo.MitarbeiterAbteilung",
                c => new
                    {
                        Mitarbeiter_Id = c.Int(nullable: false),
                        Abteilung_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Mitarbeiter_Id, t.Abteilung_Id })
                .ForeignKey("dbo.Employees", t => t.Mitarbeiter_Id, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.Abteilung_Id, cascadeDelete: true)
                .Index(t => t.Mitarbeiter_Id)
                .Index(t => t.Abteilung_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kunde", "Mitarbeiter_Id", "dbo.Employees");
            DropForeignKey("dbo.MitarbeiterAbteilung", "Abteilung_Id", "dbo.Departments");
            DropForeignKey("dbo.MitarbeiterAbteilung", "Mitarbeiter_Id", "dbo.Employees");
            DropIndex("dbo.MitarbeiterAbteilung", new[] { "Abteilung_Id" });
            DropIndex("dbo.MitarbeiterAbteilung", new[] { "Mitarbeiter_Id" });
            DropIndex("dbo.Kunde", new[] { "Mitarbeiter_Id" });
            DropTable("dbo.MitarbeiterAbteilung");
            DropTable("dbo.Kunde");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
