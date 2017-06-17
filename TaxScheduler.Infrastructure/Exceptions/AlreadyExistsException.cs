using System;

namespace TaxScheduler.Infrastructure.Exceptions
{
	public class AlreadyExistsException : Exception
	{
		public AlreadyExistsException(string message, Exception innerException) : base(message, innerException)
		{
		}
		public AlreadyExistsException(string message) : base(message)
		{
		}
	}
}
