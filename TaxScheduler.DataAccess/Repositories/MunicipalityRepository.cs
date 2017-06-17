using System;
using System.Linq;
using TaxScheduler.DataAccess.Entities;
using TaxScheduler.Infrastructure.EntityFramework;
using TaxScheduler.Infrastructure.EntityFramework.Extensions;
using TaxScheduler.Infrastructure.Exceptions;

namespace TaxScheduler.DataAccess.Repositories
{
	public class MunicipalityRepository : BaseEntityFrameworkRepository<TaskSchedulerDataContext>, IMunicipalityRepository
	{
		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="context"></param>
		public MunicipalityRepository(TaskSchedulerDataContext context) : base(context)
		{
		}

		/// <summary>
		/// Get all municipalities
		/// </summary>
		/// <returns></returns>
		public IQueryable<Municipality> Get()
		{

			var query = Context.Municipalities.Active();
			return query;
		}

		/// <summary>
		/// Get municipality by ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Municipality Get(Guid id)
		{
			var municipality = Context.Municipalities.Active().FirstOrDefault(m => m.Id == id);
			if (municipality == null)
			{
				throw new NotFoundException($"Municipality {id} not exists in the system");
			}
			return municipality;
		}
	}
}
