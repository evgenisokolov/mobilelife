namespace TaxScheduler.DataAccess.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddSoftDeletionForMinicipality : DbMigration
	{
		public override void Up()
		{
			RenameTable(name: "dbo.Mynicipalities", newName: "Municipalities");
			DropIndex("dbo.Municipalities", "IX_Municipality_Name");
			AddColumn("dbo.Municipalities", "IsActive", c => c.Boolean(nullable: false));
			CreateIndex("dbo.Municipalities", new[] { "Name", "IsActive" }, name: "IX_Municipality_Name_Active");
			CreateIndex("dbo.Municipalities", "IsActive", name: "IX_Municipality_Active");
		}

		public override void Down()
		{
			DropIndex("dbo.Municipalities", "IX_Municipality_Active");
			DropIndex("dbo.Municipalities", "IX_Municipality_Name_Active");
			DropColumn("dbo.Municipalities", "IsActive");
			CreateIndex("dbo.Municipalities", "Name", name: "IX_Municipality_Name");
			RenameTable(name: "dbo.Municipalities", newName: "Mynicipalities");
		}
	}
}
