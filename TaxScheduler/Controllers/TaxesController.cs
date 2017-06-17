using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxScheduler.Filters;
using TaxScheduler.Models;
using TaxScheduler.Services.Tax;
using MunicipalityFilter = TaxScheduler.Services.Municipality.MunicipalityFilter;

namespace TaxScheduler.Controllers
{
	[RoutePrefix("municipalities/{municipalityId:guid}/taxes")]
	public class TaxesController : ApiController
	{
		private readonly ITaxService _taxService;

		public TaxesController(ITaxService taxService)
		{
			_taxService = taxService;
		}

		[HttpGet]
		[Route("applied")]
		public HttpResponseMessage GetAppliedTax([FromUri] Guid municipalityId, [FromUri]DateTime date)
		{
			return Request.CreateResponse(HttpStatusCode.OK, _taxService.GetAppliedTax(municipalityId, date));
		}

		[HttpPost]
		[Route("")]
		public HttpResponseMessage CreateTax([FromUri] Guid municipalityId, [FromBody]NewTax tax)
		{
			if (ModelState.IsValid)
			{
				return Request.CreateResponse(HttpStatusCode.OK, _taxService.CreateTax(new Tax
				{
					Date = tax.Date,
					TaxAmount = tax.TaxAmount,
					Type = tax.Type,
					MunicipalityId = municipalityId
				}));
			}
			else
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}
		}

		[HttpGet]
		[Route("")]
		public HttpResponseMessage Get([FromUri] Guid municipalityId, [FromUri] TaxScheduler.Filters.TaxFilter filter, [FromUri]PaginationModel pagination)
		{
			var municipalityFilter = filter == null
				? null
				: new TaxScheduler.Services.Tax.TaxFilter
				{
					StartDate = filter.StartDate,
					EndDate = filter.EndDate
				};
			pagination = pagination ?? new PaginationModel();
			return Request.CreateResponse(HttpStatusCode.OK, _taxService.GetMunicipalityTaxes(municipalityId, municipalityFilter, pagination.PageNumber, pagination.PageSize));
		}

		[HttpDelete]
		[Route("{taxId:guid}")]
		public HttpResponseMessage GetAppliedTax([FromUri] Guid municipalityId, [FromUri]Guid taxId)
		{
			_taxService.DeleteTax(taxId, municipalityId);
			return Request.CreateResponse(HttpStatusCode.NoContent);
		}
	}
}
