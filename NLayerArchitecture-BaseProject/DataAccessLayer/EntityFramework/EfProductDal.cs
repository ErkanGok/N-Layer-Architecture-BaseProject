using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
	{
		public EfProductDal(Context context) : base(context)
		{
		}

		public async Task<Product> ProductwithCategoryGetByIDAsync(int id)
		{
			return await _context.Set<Product>()
								 .Include(p => p.ProductCategory) // ilişkili kategori
								 .FirstOrDefaultAsync(p => p.ID == id); // doğru PK
		}

		public async Task<List<Product>> ProductwithCategoryGetListAsync()
		{
			return await _context.Set<Product>()
						 .Include(p => p.ProductCategory) // tüm ürünleri kategori ile getir
						 .ToListAsync();
		}
	}
}
