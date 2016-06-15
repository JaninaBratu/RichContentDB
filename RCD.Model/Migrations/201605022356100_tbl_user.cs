namespace RCD.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        IsActive = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Password, unique: true);
            
            AddColumn("dbo.tblFile", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.tblFile", "UserID");
            AddForeignKey("dbo.tblFile", "UserID", "dbo.tblUser", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblFile", "UserID", "dbo.tblUser");
            DropIndex("dbo.tblUser", new[] { "Password" });
            DropIndex("dbo.tblUser", new[] { "Username" });
            DropIndex("dbo.tblFile", new[] { "UserID" });
            DropColumn("dbo.tblFile", "UserID");
            DropTable("dbo.tblUser");
        }
    }
}
