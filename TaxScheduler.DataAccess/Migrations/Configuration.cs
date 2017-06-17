using TaxScheduler.DataAccess.Entities;
using TaxScheduler.Infrastructure.EntityFramework.Extensions;
using System;
using System.Data.Entity.Migrations;

namespace TaxScheduler.DataAccess.Migrations
{

	public sealed class Configuration : DbMigrationsConfiguration<TaskSchedulerDataContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(TaskSchedulerDataContext context)
		{
			//  This method will be called after migrating to the latest version.

			//Add default municipalities
			var vilniusMunicipality = new Municipality
			{
				Id = Guid.Parse("44c6e110-159c-46ee-a7af-e17cd9752ac1"),
				Name = "Vilnius",
				IsActive = true,
				Created = DateTime.Parse("17/6/2017")
			};
			var copenhagenMunicipality = new Municipality
			{
				Id = Guid.Parse("2a8cbe9e-56b8-4b11-8672-8087f71e4228"),
				Name = "Copenhagen",
				IsActive = true,
				Created = DateTime.Parse("17/6/2017")
			};
			var minskMunicipality = new Municipality
			{
				Id = Guid.Parse("c5c2b1be-69bd-4fb9-9460-bf55c6dd820d"),
				Name = "Minsk",
				IsActive = false,
				Created = DateTime.Parse("17/6/2017")
			};
			context.Municipalities.AddOrUpdate(vilniusMunicipality);
			context.Municipalities.AddOrUpdate(copenhagenMunicipality);
			context.Municipalities.AddOrUpdate(minskMunicipality);
			context.Save();
		}
	}
}
