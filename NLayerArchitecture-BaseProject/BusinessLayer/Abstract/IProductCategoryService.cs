using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IProductCategoryService
	{
		public Task DeleteAsync(ProductCategory t);


		public Task<ProductCategory> GetByIDAsync(int id);


		public Task<List<ProductCategory>> GetListAsync();


		public  Task InsertAsync(ProductCategory t);


		public  Task UpdateAsync(ProductCategory t);
		
	}
}
