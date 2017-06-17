using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using TaxScheduler.Infrastructure.Contracts.Entities;
using TaxScheduler.Infrastructure.Exceptions;

namespace TaxScheduler.Infrastructure.EntityFramework.Extensions
{
	public static class DbContextExtension
	{
		/// <summary>
		/// Save updates to DB and specify created/updated dates for entity
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public static int Save(this DbContext context)
		{
			try
			{
				UpdateCreateUpdateDates(context);
				return context.SaveChanges();
			}

			catch (InvalidOperationException e)
			{
				throw new DataAccessException("An invalid operation exception occured on save", e);
			}
			catch (NotSupportedException e)
			{
				throw new DataAccessException("A not supported exception occured on save", e);
			}
			catch (DbEntityValidationException e)
			{
				throw new DataAccessException("An entity validation exception occured on save", e);
			}
			catch (DataException e)
			{
				throw new DataAccessException("A data access exception occured on save", e);
			}
		}

		/// <summary>
		/// Wrap DB related action in transaction
		/// </summary>
		/// <param name="context"></param>
		/// <param name="action"></param>
		/// <param name="isolationLevel"></param>
		public static void ActInTransaction(this DbContext context, Action action, IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
		{
			using (var dbContextTransaction = context.Database.BeginTransaction(isolationLevel))
			{
				try
				{
					action();
					dbContextTransaction.Commit();
				}
				catch (Exception)
				{
					dbContextTransaction.Rollback();
					throw;
				}
			}
		}

		#region private

		private static void UpdateCreateUpdateDates(DbContext context)
		{
			var entries = context.ChangeTracker.Entries().ToList();
			foreach (var added in entries.Where(x => x.Entity is ICreated && x.State == EntityState.Added).Select(entry => entry.Entity))
			{
				var created = added as ICreated;
				if (created != null)
				{
					created.Created = DateTime.UtcNow;
					var updated = added as IUpdated;
					if (updated != null)
					{
						updated.Updated = created.Created;
					}
				}
			}
			foreach (var created in entries.Where(x => x.Entity is IUpdated && x.State == EntityState.Modified).Select(entry => entry.Entity as IUpdated))
			{
				created.Updated = DateTime.UtcNow;
			}
		}

		#endregion private
	}
}
