using System;
using System.Collections.Generic;
using System.Linq;
using TaxScheduler.DataAccess;
using TaxScheduler.DataAccess.Repositories;

namespace TaxScheduler.Services.Municipality
{
	public class MunicipalityService: IMunicipalityService
	{
		private readonly IMunicipalityRepository _municipalityRepository;

		public MunicipalityService(IMunicipalityRepository municipalityRepository)
		{
			_municipalityRepository = municipalityRepository;
		}
		/// <summary>
		/// Get municipality by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Municipality Get(Guid id)
		{
			return _municipalityRepository.Get(id).Map();
		}
		/// <summary>
		/// Get paginated municipalities with filtering
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="pagenumber"></param>
		/// <param name="pagesize"></param>
		/// <returns></returns>
		public IEnumerable<Municipality> Get(MunicipalityFilter filter, int pagenumber, int pagesize)
		{
			var query = _municipalityRepository.Get(new PaginationModel(pagesize, pagenumber));
			if (filter != null && !String.IsNullOrEmpty(filter.Name))
			{
				query = query.Where(m => m.Name.StartsWith(filter.Name));
			}
			query = query.OrderBy(m => m.Name);
			return query.ToList().Select(m=>m.Map());
		}
	}
}
