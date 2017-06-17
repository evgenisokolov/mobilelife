using System;
using System.ComponentModel.DataAnnotations;
using TaxScheduler.DataAccess.Entities;
using TaxScheduler.Validation;

namespace TaxScheduler.Models
{
	public class NewTax
	{
		[Required]
		public ScheduleType Type { get; set; }
		[Required]
		[DateGreaterThan("1/1/1900")]
		public DateTime Date { get; set; }
		[Range(0, 1.0)]
		public double TaxAmount { get; set; }
	}
}