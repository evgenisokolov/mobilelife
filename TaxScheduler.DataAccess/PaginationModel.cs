namespace TaxScheduler.DataAccess
{
	/// <summary>
	/// Common pagination model
	/// </summary>
	public class PaginationModel
	{
		public PaginationModel(int pageSize, int pageNumber)
		{
			PageNumber = pageNumber;
			PageSize = pageSize;
		}

		public int PageSize { get; set; }
		public int PageNumber { get; set; }
	}
}
