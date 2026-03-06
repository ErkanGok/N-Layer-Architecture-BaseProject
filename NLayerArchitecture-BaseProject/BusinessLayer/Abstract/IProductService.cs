using DtoLayer.ProductDto;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
	public interface IProductService 
	{
		Task<GetListProductDto> ProductwithCategoryGetByIDAsync(int id);
		Task<List<GetListProductDto>> ProductwithCategoryGetListAsync();

		Task AddProductAsync(AddProductDto addProductDto);
		Task UpdateProductAsync(UpdateProductDto updateProductDto);
		Task DeleteAsync(int id);
	}
}
