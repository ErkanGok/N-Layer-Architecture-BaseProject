using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
	public interface IProductService : IGenericService<Product>
	{
		Task<Product> ProductwithCategoryGetByIDAsync(int id);
		Task<List<Product>> ProductwithCategoryGetListAsync();
	}
}
