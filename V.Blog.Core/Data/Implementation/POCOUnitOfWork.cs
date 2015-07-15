using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using V.Blog.Core.Data.Interfaces;

namespace V.Blog.Core.Data.Implementation
{
	public class POCOUnitOfWork : IUnitOfWork
	{
		private readonly DbContext _context;

		public POCOUnitOfWork(DbContext context)
		{
			_context = context;
		}
		public void Commit()
		{
			try
			{
				_context.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				foreach (var eve in e.EntityValidationErrors)
				{
					System.Diagnostics.Trace.WriteLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State));
					foreach (var ve in eve.ValidationErrors)
					{
						System.Diagnostics.Trace.WriteLine(string.Format("- Property: \"{0}\", Error: \"{1}\"",
							ve.PropertyName, ve.ErrorMessage));
					}
				}
				throw;
			}
		}
	}
}
