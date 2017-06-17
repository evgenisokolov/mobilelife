using System.ComponentModel.DataAnnotations;

namespace TaxScheduler.Filters
{
	/// <summary>
	/// Pagination
	/// </summary>
	public class PaginationModel
	{
		public PaginationModel()
		{
			PageNumber = 0;
			PageSize = 100;
		}
		[Range(0, 10000)]
		public int PageSize { get; set; }
		[Range(0, 100)]
		public int PageNumber { get; set; }
	}
}
