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

        public OrderHeader GetLast(Expression<Func<OrderHeader, bool>> filter, Expression<Func<OrderHeader, DateTime>> orderByDescending, bool tracked = false, string includeProperties = null)
        {
            IQueryable<OrderHeader> query = _db.Set<OrderHeader>();

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.OrderByDescending(orderByDescending).FirstOrDefault();
        }

        public T GetLast(Expression<Func<T, bool>> filter, bool tracked = false, string includeProperties = null)
        {
            IQueryable<T> query = _db.Set<T>();

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.OrderByDescending(x => EF.Property<int>(x, "Id")).FirstOrDefault();
        }
    }
}
