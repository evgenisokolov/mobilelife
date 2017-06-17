using System;
using System.ComponentModel.DataAnnotations;

namespace TaxScheduler.Validation
{
	[AttributeUsage(AttributeTargets.Property)]
	public class DateGreaterThanAttribute : ValidationAttribute
	{
		private readonly DateTime _startDate;

		public DateGreaterThanAttribute(string startDate)
		{
			_startDate =  DateTime.Parse(startDate);
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			DateTime date = (DateTime)value;
			
			if (_startDate > date)
			{
				return new ValidationResult($"Date could not be earlier then {_startDate}");
			}
			else
			{
				return ValidationResult.Success;
			}
		}
	}
}