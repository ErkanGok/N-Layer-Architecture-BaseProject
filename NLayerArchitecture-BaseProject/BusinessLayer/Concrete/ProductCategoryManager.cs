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
	public class ProductCategoryManager : IProductCategoryService
	{
		private readonly IProductCategoryDal _productCategoryDal;

		public ProductCategoryManager(IProductCategoryDal productCategoryDal)
		{
			_productCategoryDal = productCategoryDal;
		}

		public async Task DeleteAsync(ProductCategory t)
		{
			await _productCategoryDal.DeleteAsync(t);
		}

		public async Task<ProductCategory> GetByIDAsync(int id)
		{
			return await _productCategoryDal.GetByIDAsync(id);
		}

		public Task<List<ProductCategory>> GetListAsync()
		{
			return _productCategoryDal.GetListAsync();
		}

		public async Task InsertAsync(ProductCategory t)
		{
			await _productCategoryDal.InsertAsync(t);
		}

		public async Task UpdateAsync(ProductCategory t)
		{
			await _productCategoryDal.UpdateAsync(t);
		}
	}
}
