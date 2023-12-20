﻿using System.Linq.Expressions;

namespace Flash.Repositories
{
	public interface IRepsitory<T> where T : class
	{
		IEnumerable<T> GetAll(Expression<Func<T, bool>> Filter = null, string? includeProperties = null);
		T Get(Expression<Func<T, bool>> Filter, bool tracked = false, string? includeProperties = null);
		void Add(T entity);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entity);
	}
}
