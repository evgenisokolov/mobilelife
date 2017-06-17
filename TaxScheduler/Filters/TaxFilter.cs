using System;

namespace TaxScheduler.Filters
{
	/// <summary>
	/// Filters for municipality
	/// </summary>
	public class TaxFilter
	{
		/// <summary>
		/// Start Date
		/// </summary>
		public DateTime? StartDate { get; set; }
		/// <summary>
		/// End Date
		/// </summary>
		public DateTime? EndDate { get; set; }
	}
}
