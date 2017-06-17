using System;
using System.Linq;
using TaxScheduler.DataAccess.Entities;

namespace TaxScheduler.DataAccess.Repositories
{
	public interface IMunicipalityRepository
	{
		/// <summary>
		/// Get all municipalities
		/// </summary>
		/// <returns></returns>
		IQueryable<Municipality> Get();

		/// <summary>
		/// Get municipality by ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Municipality Get(Guid id);
	}
}
