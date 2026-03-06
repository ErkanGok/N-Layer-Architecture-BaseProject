using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitofWorks;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ProductCategoryManager(IProductCategoryDal productCategoryDal, IUnitofWork unitofWork) : IProductCategoryService
	{
		private readonly IProductCategoryDal _productCategoryDal = productCategoryDal;

		public async Task DeleteAsync(ProductCategory t)
		{
			await _productCategoryDal.DeleteAsync(t);
			await unitofWork.SaveChangesAsync();
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
			await unitofWork.SaveChangesAsync();
		}

		public async Task UpdateAsync(ProductCategory t)
		{
			await _productCategoryDal.UpdateAsync(t);
			await unitofWork.SaveChangesAsync();
		}
	}
}
