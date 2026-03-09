using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class GenericRepository<T>(Context context) : IGenericDal<T> where T : class
	{
		protected Context Context = context;

		private readonly DbSet<T> _dbset = context.Set<T>();
		public async ValueTask AddAsync(T entity) => await _dbset.AddAsync(entity);


		public void Delete(T entity) => _dbset.Remove(entity);


		public IQueryable<T> GetAll() => _dbset.AsQueryable().AsNoTracking();


		public ValueTask<T?> GetByIdAsync(int id) => _dbset.FindAsync(id);


		public void Update(T entity) => _dbset.Update(entity);


		public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbset.Where(predicate).AsNoTracking();
	}
}
