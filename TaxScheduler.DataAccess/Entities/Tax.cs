using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaxScheduler.Infrastructure.Contracts.Entities;

namespace TaxScheduler.DataAccess.Entities
{
	[Table("Taxes")]
	public class Tax : ICreated, IUpdated
	{
		[Key]
		public Guid Id { get; set; }

		public double Amount { get; set; }

		[Index("IX_Municipality_StartDate_EndDate_Type", 0)]
		public ScheduleType Type { get; set; }
		[Index("IX_Municipality_StartDate_EndDate", 0)]
		[Index("IX_Municipality_StartDate_EndDate_Type", 1)]
		public DateTime StartDate { get; set; }
		[Index("IX_Municipality_StartDate_EndDate", 1)]
		[Index("IX_Municipality_StartDate_EndDate_Type", 2)]
		public DateTime EndDate { get; set; }

		public DateTime Created { get; set; }
		public DateTime? Updated { get; set; }

		public Guid MunicipalityId { get; set; }
		[ForeignKey("MunicipalityId")]
		public virtual Municipality Mynicipality { get; set; }
	}
}
