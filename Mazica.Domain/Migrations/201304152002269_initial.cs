namespace Mazica.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mazes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Data = c.Binary(nullable: false),
                        Width = c.Long(nullable: false),
                        Height = c.Long(nullable: false),
                        Depth = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Paths",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Data = c.Binary(nullable: false),
                        Maze_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Mazes", t => t.Maze_Id, cascadeDelete: true)
                .Index(t => t.Maze_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Paths", new[] { "Maze_Id" });
            DropForeignKey("dbo.Paths", "Maze_Id", "dbo.Mazes");
            DropTable("dbo.Paths");
            DropTable("dbo.Mazes");
        }
    }
}
