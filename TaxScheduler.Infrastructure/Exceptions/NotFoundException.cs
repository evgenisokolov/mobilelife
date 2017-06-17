﻿using System;

namespace TaxScheduler.Infrastructure.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}
		public NotFoundException(string message) : base(message)
		{
		}
	}
}
