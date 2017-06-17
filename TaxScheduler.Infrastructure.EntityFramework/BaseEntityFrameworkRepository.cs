using System.Data.Entity;

namespace TaxScheduler.Infrastructure.EntityFramework
{
	/// <summary>
	/// Base repository for Entity Framework implementation
	/// </summary>
	/// <typeparam name="TContext"></typeparam>
	public class BaseEntityFrameworkRepository<TContext> where TContext : DbContext, new()
	{
		protected TContext Context { get; private set; }

		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="context"></param>
		public BaseEntityFrameworkRepository(TContext context)
		{
			Context = context;
		}
	}
}
