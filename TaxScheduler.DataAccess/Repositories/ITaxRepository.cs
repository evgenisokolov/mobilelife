using System;
using System.Linq;
using TaxScheduler.DataAccess.Entities;

namespace TaxScheduler.DataAccess.Repositories
{
	public interface ITaxRepository
	{
		/// <summary>
		/// Get tax by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Tax Get(Guid id);
		/// <summary>
		/// Get all taxes
		/// </summary>
		/// <returns></returns>
		IQueryable<Tax> Get();
		/// <summary>
		/// Create new tax
		/// </summary>
		/// <param name="tax"></param>
		void Create(Tax tax);
		/// <summary>
		/// Delete tax
		/// </summary>
		/// <param name="id"></param>
		void Delete(Guid id);
	}
}
