namespace TaxScheduler.DataAccess.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddMunicipalityTable : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Mynicipalities",
				c => new
				{
					Id = c.Guid(nullable: false),
					Name = c.String(nullable: false, maxLength: 255),
					Created = c.DateTime(nullable: false),
					Updated = c.DateTime(),
				})
				.PrimaryKey(t => t.Id)
				.Index(t => t.Name, name: "IX_Municipality_Name");

		}

		public override void Down()
		{
			DropIndex("dbo.Mynicipalities", "IX_Municipality_Name");
			DropTable("dbo.Mynicipalities");
		}
	}
}
