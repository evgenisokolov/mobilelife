using System;
using System.Linq;
using TaxScheduler.DataAccess.Entities;
using TaxScheduler.Infrastructure.EntityFramework;
using TaxScheduler.Infrastructure.EntityFramework.Extensions;
using TaxScheduler.Infrastructure.Exceptions;

namespace TaxScheduler.DataAccess.Repositories
{
	public class TaxRepository: BaseEntityFrameworkRepository<TaskSchedulerDataContext>, ITaxRepository
	{
		/// <summary>
		/// .ctor
		/// </summary>
		/// <param name="context"></param>
		public TaxRepository(TaskSchedulerDataContext context) : base(context)
		{
		}
		/// <summary>
		/// Get tax by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Tax Get(Guid id)
		{
			var tax = Context.Taxes.FirstOrDefault(m => m.Id == id);
			if (tax == null)
			{
				throw new NotFoundException($"Tax {id} not exists in the system");
			}
			return tax;
		}
		/// <summary>
		/// Get all taxes
		/// </summary>
		/// <returns></returns>
		public IQueryable<Tax> Get()
		{
			return Context.Taxes;
		}
		/// <summary>
		/// Create new tax
		/// </summary>
		/// <param name="tax"></param>
		public void Create(Tax tax)
		{
			Context.Taxes.Add(tax);
			Context.Save();
		}
		/// <summary>
		/// Delete tax
		/// </summary>
		/// <param name="id"></param>
		public void Delete(Guid id)
		{
			var tax = Context.Taxes.FirstOrDefault(m => m.Id == id);
			if (tax == null)
			{
				throw new NotFoundException($"Tax {id} not exists in the system");
			}
			Context.Taxes.Remove(tax);
			Context.Save();
		}
	}
}
