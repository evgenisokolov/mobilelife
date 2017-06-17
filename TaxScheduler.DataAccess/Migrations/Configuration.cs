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

			var vilnusTax1 = new Tax
			{
				Id = Guid.Parse("044720d9-cda4-44e9-9ac6-7f71f2abdb67"),
				Amount = 0.1,
				Type = ScheduleType.Yearly,
				StartDate = DateTime.Parse("1/1/2016"),
				EndDate = DateTime.Parse("31/12/2016"),
				MunicipalityId = Guid.Parse("44c6e110-159c-46ee-a7af-e17cd9752ac1"),
				Created = DateTime.Parse("17/6/2017")
			};
			var vilnusTax2 = new Tax
			{
				Id = Guid.Parse("d1f5137e-7150-4768-a191-ef6d73894649"),
				Amount = 0.4,
				Type = ScheduleType.Montly,
				StartDate = DateTime.Parse("1/5/2016"),
				EndDate = DateTime.Parse("31/5/2016"),
				MunicipalityId = Guid.Parse("44c6e110-159c-46ee-a7af-e17cd9752ac1"),
				Created = DateTime.Parse("17/6/2017")
			};

			var vilnusTax3 = new Tax
			{
				Id = Guid.Parse("e448430a-75aa-47b1-94a4-a1c3b4fd2b14"),
				Amount = 0.1,
				Type = ScheduleType.Daily,
				StartDate = DateTime.Parse("1/1/2016"),
				EndDate = DateTime.Parse("1/1/2016"),
				MunicipalityId = Guid.Parse("44c6e110-159c-46ee-a7af-e17cd9752ac1"),
				Created = DateTime.Parse("17/6/2017")
			};
			var vilnusTax4 = new Tax
			{
				Id = Guid.Parse("ce503423-0f6a-425a-b8c9-f7480512e015"),
				Amount = 0.1,
				Type = ScheduleType.Daily,
				StartDate = DateTime.Parse("25/12/2016"),
				EndDate = DateTime.Parse("25/12/2016"),
				MunicipalityId = Guid.Parse("2a8cbe9e-56b8-4b11-8672-8087f71e4228"),
				Created = DateTime.Parse("17/6/2017")
			};

			var cphTax1 = new Tax
			{
				Id = Guid.Parse("cf261f73-2291-43ef-835f-44b7acae3043"),
				Amount = 0.5,
				Type = ScheduleType.Daily,
				StartDate = DateTime.Parse("14/1/2016"),
				EndDate = DateTime.Parse("14/1/2016"),
				MunicipalityId = Guid.Parse("2a8cbe9e-56b8-4b11-8672-8087f71e4228"),
				Created = DateTime.Parse("17/6/2017")
			};

			var cphTax2 = new Tax
			{
				Id = Guid.Parse("9dd6f1d2-a9ce-465f-a014-545f286e2e3f"),
				Amount = 0.2,
				Type = ScheduleType.Daily,
				StartDate = DateTime.Parse("1/1/2016"),
				EndDate = DateTime.Parse("1/12/2016"),
				MunicipalityId = Guid.Parse("2a8cbe9e-56b8-4b11-8672-8087f71e4228"),
				Created = DateTime.Parse("17/6/2017")
			};

			context.Taxes.AddOrUpdate(vilnusTax1);
			context.Taxes.AddOrUpdate(vilnusTax2);
			context.Taxes.AddOrUpdate(vilnusTax3);
			context.Taxes.AddOrUpdate(vilnusTax4);
			context.Taxes.AddOrUpdate(cphTax1);
			context.Taxes.AddOrUpdate(cphTax2);

			context.Save();
		}
	}
}
