using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public async Task DeleteAsync(Product t)
		{
			await _productDal.DeleteAsync(t);
		}

		public async Task<Product> GetByIDAsync(int id)
		{
			return await _productDal.GetByIDAsync(id);
		}

		public async Task<List<Product>> GetListAsync()
		{
			return await _productDal.GetListAsync();
		}

		public async Task InsertAsync(Product t)
		{
			await _productDal.InsertAsync(t);
		}

		public async Task<Product> ProductwithCategoryGetByIDAsync(int id)
		{
			return await _productDal.ProductwithCategoryGetByIDAsync(id);
		}

		public async Task<List<Product>> ProductwithCategoryGetListAsync()
		{
			return await _productDal.ProductwithCategoryGetListAsync();
		}

		public async Task UpdateAsync(Product t)
		{
			await _productDal.UpdateAsync(t);
		}
	}
}
