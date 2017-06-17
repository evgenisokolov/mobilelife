namespace TaxScheduler.DataAccess.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddTaxTable : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Taxes",
				c => new
				{
					Id = c.Guid(nullable: false),
					Amount = c.Double(nullable: false),
					Type = c.Int(nullable: false),
					StartDate = c.DateTime(nullable: false),
					EndDate = c.DateTime(nullable: false),
					Created = c.DateTime(nullable: false),
					Updated = c.DateTime(),
					MunicipalityId = c.Guid(nullable: false),
				})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Municipalities", t => t.MunicipalityId, cascadeDelete: true)
				.Index(t => new { t.Type, t.StartDate, t.EndDate }, name: "IX_Municipality_StartDate_EndDate_Type")
				.Index(t => new { t.StartDate, t.EndDate }, name: "IX_Municipality_StartDate_EndDate")
				.Index(t => t.MunicipalityId);

		}

		public override void Down()
		{
			DropForeignKey("dbo.Taxes", "MunicipalityId", "dbo.Municipalities");
			DropIndex("dbo.Taxes", new[] { "MunicipalityId" });
			DropIndex("dbo.Taxes", "IX_Municipality_StartDate_EndDate");
			DropIndex("dbo.Taxes", "IX_Municipality_StartDate_EndDate_Type");
			DropTable("dbo.Taxes");
		}
	}
}
