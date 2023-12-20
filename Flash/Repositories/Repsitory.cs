using Flash.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Flash.Models;

namespace Flash.Repositories
{
	public class Repsitory<T> : IRepsitory<T> where T : class
	{
		private readonly aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context _db;
		internal DbSet<T> DbSet;
		public Repsitory(aspnetFlashea0b459b975b45bcb0db4ccd1080c8c3Context db)
		{
			_db = db;
			this.DbSet = _db.Set<T>();
		}

		public void Add(T entity)
		{
			DbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> Filter, bool tracked = false, string? includeProperties = null)
		{

			IQueryable<T> query;
			if (tracked)
			{
				query = DbSet;
			}
			else
			{
				query = DbSet.AsNoTracking();
			}
			query = query.Where(Filter);
			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}
			}

			return query.FirstOrDefault();

		}

		public IEnumerable<T> GetAll(Expression<Func<T, bool>>? Filter, string? includeProperties = null)
		{
			IQueryable<T> query = DbSet;
			if (Filter != null)
			{
				query = query.Where(Filter);
			}
			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}
			}
			return query.ToList();
		}
		public void RemoveRange(IEnumerable<T> entity)
		{
			DbSet.RemoveRange(entity);
		}

		public void Remove(T entity)
		{
			DbSet.Remove(entity);
		}
	}
}
