using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using V.Blog.Core.Data.Interfaces;

namespace V.Blog.Core.Data.Implementation
{
	public class EntityRepository<T> : IRepository<T> where T : class
	{
		protected ObjectSet<T> objectSet;

		public EntityRepository(ObjectContext context)
		{
			objectSet = context.CreateObjectSet<T>();
		}

		public DbSet<T> ObjectSet()
		{
			throw new NotImplementedException();
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
			objectSet.AddObject(Entity);
		}

		public void Delete(T Entity)
		{
			objectSet.DeleteObject(Entity);
		}

		void IRepository<T>.Remove(T Entity)
		{
			Delete(Entity);
		}
	}
}