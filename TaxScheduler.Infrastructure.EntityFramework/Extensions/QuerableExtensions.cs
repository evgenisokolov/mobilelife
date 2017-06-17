using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using TaxScheduler.Infrastructure.Contracts.Entities;

namespace TaxScheduler.Infrastructure.EntityFramework.Extensions
{
	public static class QuerableExtensions
	{
		/// <summary>
		/// Get only active entries
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <returns></returns>
		public static IQueryable<T> Active<T>(this IQueryable<T> query) where T : class, IIsActive
		{
			return query.Where(entity => entity.IsActive);
		}

		/// <summary>
		/// Get only inactive entries
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <returns></returns>
		public static IQueryable<T> NotActive<T>(this IQueryable<T> query) where T : class, IIsActive
		{
			return query.Where(entity => !entity.IsActive);
		}

		/// <summary>
		/// Create x=>x.propertyName
		/// </summary>
		/// <param name="entityType"></param>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		private static LambdaExpression GetPropertyLambdaExpression(Type entityType, string propertyName)
		{
			ParameterExpression arg = Expression.Parameter(entityType, "x");
			MemberExpression property = Expression.Property(arg, propertyName);
			return Expression.Lambda(property, new ParameterExpression[] { arg });
		}

		/// <summary>
		/// Get page from collection, set default order by Id if it was not set
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <param name="pagenumber">Pagenumber starting from 0</param>
		/// <param name="pagesize">PageSize - number of entries on page</param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException">Thrown when GetPage used without ordering and cannot apply default oreder by id</exception>>
		public static IQueryable<T> GetPage<T>(this IQueryable<T> query, int pagenumber, int pagesize)
		{
			int skip = pagenumber * pagesize;
			if (query.Expression.Type == typeof(IOrderedQueryable<T>))
			{
				return query.Skip(() => skip).Take(() => pagesize);
			}
			//set default order by id
			const string defaultSortColumn = "Id";
			var entityType = typeof(T);
			var propertyInfo = entityType.GetProperty(defaultSortColumn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
			if(propertyInfo == null)
				throw new InvalidOperationException("You need to define order before using getpage");
			var selector = GetPropertyLambdaExpression(entityType, defaultSortColumn);
			var genericMethod = GetGenericMethod(entityType, propertyInfo.PropertyType, "OrderBy");

			query = (IOrderedQueryable<T>)genericMethod.Invoke(genericMethod, new object[] { query, selector });
			return query.Skip(() => skip).Take(() => pagesize);
		}

		#region private

		private static MethodInfo GetGenericMethod(Type entityType, Type entityPropertyType, string methodName)
		{
			//Get System.Linq.Queryable.OrderBy() method.
			var enumarableType = typeof(Queryable);
			var method = enumarableType.GetMethods().Where(m => m.Name == methodName && m.IsGenericMethodDefinition).Where(m =>
			{
				var parameters = m.GetParameters().ToList();
				//Put more restriction here to ensure selecting the right overload                
				return parameters.Count == 2; //overload that has 2 parameters
			}).Single();
			//The linq's OrderBy<TSource, TKey> has two generic types, which provided here
			return method.MakeGenericMethod(entityType, entityPropertyType);
		}

		#endregion
	}
}
