namespace TaxScheduler.Services.Municipality
{
	public static class MunicipalityMappingExtensions
	{
		public static Municipality Map(this DataAccess.Entities.Municipality entity)
		{
			return new Municipality
			{
				Id = entity.Id,
				Name = entity.Name
			};
		}
	}
}
