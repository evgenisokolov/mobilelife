using System.Data.Entity;
using TaxScheduler.DataAccess.Entities;

namespace TaxScheduler.DataAccess
{
	public class TaskSchedulerDataContext : DbContext
	{
		public DbSet<Municipality> Municipalities { get; set; }
		public DbSet<Tax> Taxes { get; set; }
	}
}
