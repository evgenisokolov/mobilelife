using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using TaxScheduler.Infrastructure.Exceptions;

namespace TaxScheduler.ErrorHandling
{
	public class CommonExceptionHandler : ExceptionHandler
	{
		public override void Handle(ExceptionHandlerContext context)
		{
			if (context.Exception is NotFoundException)
			{
				context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.NotFound, context.Exception.Message));
			}else if (context.Exception is ArgumentException)
			{
				context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.BadRequest, context.Exception.Message));
			}
			else
			{
				context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.InternalServerError, "Unknown error accoured"));
			}
			base.Handle(context);
		}
	}
}