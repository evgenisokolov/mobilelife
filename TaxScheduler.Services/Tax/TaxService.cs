using System;
using System.Collections.Generic;
using System.Linq;
using TaxScheduler.DataAccess.Repositories;
using TaxScheduler.Infrastructure.EntityFramework.Extensions;

namespace TaxScheduler.Services.Tax
{
	public class TaxService : ITaxService
	{
		private readonly ITaxRepository _taxRepository;
		private readonly IMunicipalityRepository _municipalityRepository;
		/// <summary>
		/// .ctor
		/// </summary>
		public TaxService(ITaxRepository taxRepository, IMunicipalityRepository municipalityRepository)
		{
			_taxRepository = taxRepository;
			_municipalityRepository = municipalityRepository;
		}
		/// <summary>
		/// Get tax by ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Tax Get(Guid id)
		{
			return _taxRepository.Get(id).Map();
		}
		/// <summary>
		/// Get all taxes applied to municipality
		/// </summary>
		/// <param name="municipalityId"></param>
		/// <param name="filter"></param>
		/// <param name="pagenumber"></param>
		/// <param name="pagesize"></param>
		/// <returns></returns>
		public IEnumerable<Tax> GetMunicipalityTaxes(Guid municipalityId, TaxFilter filter, int pagenumber, int pagesize)
		{
			//check if munipality exists and active (exception will be thrown in case it's not)
			_municipalityRepository.Get(municipalityId);

			var query =
				_taxRepository.Get()
					.Where(t => t.MunicipalityId == municipalityId);
			if (filter != null)
			{
				if (filter.StartDate.HasValue)
				{
					query = query.Where(t => t.StartDate >= filter.StartDate.Value);
				}
				if (filter.EndDate.HasValue)
				{
					query = query.Where(t => t.StartDate <= filter.EndDate.Value);
				}
			}

			return query.OrderBy(t => t.Type).GetPage(pagenumber, pagesize).ToList().Select(t => t.Map());
		}

		/// <summary>
		/// Get tax that applied on specified date in municipality
		/// </summary>
		/// <param name="municipalityId"></param>
		/// <param name="date"></param>
		/// <returns></returns>
		public Tax GetAppliedTax(Guid municipalityId, DateTime date)
		{
			date = date.Date; // get rid of seconds
			//check if munipality exists and active (exception will be thrown in case it's not)
			_municipalityRepository.Get(municipalityId);
			
			//get tax for chhosen date with highest priority
			return _taxRepository.Get()
				.Where(t => t.MunicipalityId == municipalityId && t.StartDate <= date && t.EndDate > date)
				.OrderBy(t => t.Type)
				.FirstOrDefault().Map();
		}

		/// <summary>
		/// Create new tax
		/// </summary>
		/// <param name="tax"></param>
		public Tax CreateTax(Tax tax)
		{
			//check if munipality exists and active (exception will be thrown in case it's not)
			_municipalityRepository.Get(tax.MunicipalityId);


			tax.Id = Guid.NewGuid();
			tax.Date = tax.Date.Date; //get rid of seconds

			if (_taxRepository.Get()
					.Any(t => t.MunicipalityId == tax.MunicipalityId && t.StartDate == tax.Date && t.Type == tax.Type))
			{
				throw new ArgumentException($"Tax with a type {tax.Type} is already exists on {tax.Date} in municipality {tax.MunicipalityId}");
			}

			_taxRepository.Create(tax.Map());

			return tax;
		}

		/// <summary>
		/// Delete tax by ID
		/// </summary>
		/// <param name="id"></param>
		/// <param name="municipalityId"></param>
		public void DeleteTax(Guid id, Guid municipalityId)
		{
			//check if munipality exists and active (exception will be thrown in case it's not)
			_municipalityRepository.Get(municipalityId);

			_taxRepository.Delete(id);
		}
	}
}
