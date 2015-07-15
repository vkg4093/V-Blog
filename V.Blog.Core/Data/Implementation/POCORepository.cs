using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using V.Blog.Core.Data.Interfaces;

namespace V.Blog.Core.Data.Implementation
{
	public class POCORepository<T> : IRepository<T> where T : class
	{
		protected DbSet<T> objectSet;
		private DbContext _context;
      
		public POCORepository(DbContext context)
		{
			_context = context;
			objectSet = context.Set<T>();
		}

		public DbSet<T> ObjectSet()
		{
			return objectSet;
		}

		public IQueryable<T> FindAll()
		{
			return objectSet;
		}

		public IQueryable<T> FindAllBy(System.Linq.Expressions.Expression<Func<T, bool>> Predicate)
		{
			return objectSet.Where(Predicate);
		}

		public IEnumerable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> Predicate)
		{
			return FindAllBy(Predicate);
		}

		public T FindBy(System.Linq.Expressions.Expression<Func<T, bool>> Predicate)
		{
			return FindAllBy(Predicate).FirstOrDefault();
		}

		public void Add(T Entity)
		{
			objectSet.Add(Entity);
		}

		public void Delete(T Entity)
		{
			objectSet.Remove(Entity);
		}

		void IRepository<T>.Remove(T Entity)
		{
			Delete(Entity);
		}

	}
}