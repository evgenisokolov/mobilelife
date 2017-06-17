using System;
using System.Collections.Generic;

namespace TaxScheduler.Services.Tax
{
	public interface ITaxService
	{
		/// <summary>
		/// Get tax by ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Tax Get(Guid id);

		/// <summary>
		/// Get all taxes applied to municipality
		/// </summary>
		/// <param name="municipalityId"></param>
		/// <param name="filter"></param>
		/// <param name="pagenumber"></param>
		/// <param name="pagesize"></param>
		/// <returns></returns>
		IEnumerable<Tax> GetMunicipalityTaxes(Guid municipalityId, TaxFilter filter, int pagenumber, int pagesize);

		/// <summary>
		/// Get tax that applied on specified date in municipality
		/// </summary>
		/// <param name="municipalityId"></param>
		/// <param name="date"></param>
		/// <returns></returns>
		Tax GetAppliedTax(Guid municipalityId, DateTime date);

		/// <summary>
		/// Create new tax
		/// </summary>
		/// <param name="tax"></param>
		Tax CreateTax(Tax tax);

		/// <summary>
		/// Delete tax by ID
		/// </summary>
		/// <param name="id"></param>
		void DeleteTax(Guid id);
	}
}
