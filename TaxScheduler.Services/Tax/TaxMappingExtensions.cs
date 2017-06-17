using System;
using TaxScheduler.DataAccess.Entities;

namespace TaxScheduler.Services.Tax
{
	public static class TaxMappingExtensions
	{
		public static Tax Map(this DataAccess.Entities.Tax entity)
		{
			return new Tax
			{
				Id = entity.Id,
				Type = entity.Type,
				TaxAmount = entity.Amount,
				Date = entity.StartDate,
				MunicipalityId = entity.MunicipalityId
			};
		}

		public static DataAccess.Entities.Tax Map(this Tax entity)
		{
			var endDate = DateTime.Now;
			switch (entity.Type)
			{
				case ScheduleType.Daily:
					endDate = entity.Date.AddDays(1);
					break;
				case ScheduleType.Weekly:
					endDate = entity.Date.AddDays(7);
					break;
				case ScheduleType.Montly:
					endDate = entity.Date.AddMonths(1);
					break;
				case ScheduleType.Yearly:
					endDate = entity.Date.AddYears(1);
					break;
			}
			return new DataAccess.Entities.Tax
			{
				Id = entity.Id,
				Type = entity.Type,
				Amount = entity.TaxAmount,
				StartDate = entity.Date,
				EndDate = endDate,
				MunicipalityId = entity.MunicipalityId
			};
		}
	}
}
