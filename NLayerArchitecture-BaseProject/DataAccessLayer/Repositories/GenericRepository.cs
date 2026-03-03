using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		protected readonly Context _context;

		public GenericRepository(Context context)
		{
			_context = context;
		}

		public async Task InsertAsync(T t)
		{
			await _context.Set<T>().AddAsync(t);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(T t)
		{
			_context.Set<T>().Remove(t);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(T t)
		{
			_context.Set<T>().Update(t);
			await _context.SaveChangesAsync();
		}

		public async Task<List<T>> GetListAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<T> GetByIDAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}
	}
}
