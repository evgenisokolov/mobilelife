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

		[HttpGet]
		[Route("{municipalityId:guid}")]
		public HttpResponseMessage GetOne([FromUri] Guid municipalityId)
		{
			return Request.CreateResponse(HttpStatusCode.OK, _municipalityService.Get(municipalityId));
		}

		[HttpGet]
		[Route("")]
		public HttpResponseMessage Get([FromUri] MunicipalityFilter filter, [FromUri]PaginationModel pagination)
		{
			var mubicipalityFilter = filter == null
				? null
				: new MunicipalityFilter
				{
					Name = filter.Name
				};
			pagination = pagination ?? new PaginationModel();
			return Request.CreateResponse(HttpStatusCode.OK, _municipalityService.Get(mubicipalityFilter, pagination.PageNumber, pagination.PageSize));
		}
	}
}
