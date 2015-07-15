using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace V.Blog.Core.Data.Interfaces
{

	public interface IRepository<T> where T : class
	{
		DbSet<T> ObjectSet();
		IQueryable<T> FindAll();
		IQueryable<T> FindAllBy(System.Linq.Expressions.Expression<Func<T, bool>> Predicate);
		T FindBy(System.Linq.Expressions.Expression<Func<T, bool>> Predicate);
		IEnumerable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> Predicate);
		void Add(T Entity);
		void Delete(T Entity);
		void Remove(T Entity);
	}
}