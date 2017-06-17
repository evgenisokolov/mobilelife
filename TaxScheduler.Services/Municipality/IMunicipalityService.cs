using System;
using System.Collections.Generic;

namespace TaxScheduler.Services.Municipality
{
	public interface IMunicipalityService
	{
		/// <summary>
		/// Get municipality by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Municipality Get(Guid id);
		/// <summary>
		/// Get paginated municipalities with filtering
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="pagenumber"></param>
		/// <param name="pagesize"></param>
		/// <returns></returns>
		IEnumerable<Municipality> Get(MunicipalityFilter filter, int pagenumber, int pagesize);
	}
}
