using System;

namespace TaxScheduler.Infrastructure.Contracts.Entities
{
	public interface IUpdated
	{
		DateTime? Updated { get; set; }
	}
}
