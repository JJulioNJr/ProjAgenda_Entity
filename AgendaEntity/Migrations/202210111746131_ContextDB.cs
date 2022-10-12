namespace AgendaEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContextDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Idade = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.TelephoneBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Mobile = c.String(),
                        NameId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.NameId)
                .Index(t => t.NameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TelephoneBooks", "NameId", "dbo.People");
            DropIndex("dbo.TelephoneBooks", new[] { "NameId" });
            DropTable("dbo.TelephoneBooks");
            DropTable("dbo.People");
        }
    }
}
