using System;
using TaxScheduler.DataAccess.Entities;

namespace TaxScheduler.Services.Tax
{
	public class Tax
	{
		public Guid Id { get; set; }
		public ScheduleType Type { get; set; }
		public DateTime Date { get; set; }
		public double TaxAmount { get; set; }
		public Guid MunicipalityId { get; set; }
	}
}
