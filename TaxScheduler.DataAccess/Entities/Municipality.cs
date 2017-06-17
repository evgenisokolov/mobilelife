using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaxScheduler.Infrastructure.Contracts.Entities;

namespace TaxScheduler.DataAccess.Entities
{
	[Table("Municipalities")]
	public class Municipality : ICreated, IUpdated, IIsActive
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		[StringLength(255)]
		[Index("IX_Municipality_Name_Active", 0)]
		public string Name { get; set; }

		public DateTime Created { get; set; }
		public DateTime? Updated { get; set; }
		[Index("IX_Municipality_Active")]
		[Index("IX_Municipality_Name_Active", 1)]
		public bool IsActive { get; set; }
	}
}
