using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TaxScheduler.Controllers
{
	[Route("api/[controller]")]
	public class MunicipalitiesController : Controller
	{
		// GET api/municipalities
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/municipalities/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/municipalities
		[HttpPost]
		public void Post([FromBody]string value)
		{
		}

		// PUT api/municipalities/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/municipalities/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
