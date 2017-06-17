using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxScheduler.Filters;
using TaxScheduler.Services.Municipality;
using MunicipalityFilter = TaxScheduler.Services.Municipality.MunicipalityFilter;

namespace TaxScheduler.Controllers
{
	[RoutePrefix("municipalities")]
	public class MunicipalitiesController : ApiController
	{
		private IMunicipalityService _municipalityService;

		public MunicipalitiesController(IMunicipalityService municipalityService)
		{
			_municipalityService = municipalityService;
		}
		/// <summary>
		/// Get municipality by ID
		/// </summary>
		/// <param name="municipalityId"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("{municipalityId:guid}")]
		public HttpResponseMessage GetOne([FromUri] Guid municipalityId)
		{
			return Request.CreateResponse(HttpStatusCode.OK, _municipalityService.Get(municipalityId));
		}
		/// <summary>
		/// Get all municipalities with filters
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="pagination"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("")]
		public HttpResponseMessage Get([FromUri] MunicipalityFilter filter, [FromUri]PaginationModel pagination)
		{
			var municipalityFilter = filter == null
				? null
				: new MunicipalityFilter
				{
					Name = filter.Name
				};
			pagination = pagination ?? new PaginationModel();
			return Request.CreateResponse(HttpStatusCode.OK, _municipalityService.Get(municipalityFilter, pagination.PageNumber, pagination.PageSize));
		}
	}
}
