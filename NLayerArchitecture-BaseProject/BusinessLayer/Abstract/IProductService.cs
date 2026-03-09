using App.Services;
using BusinessLayer.Products.Create;
using BusinessLayer.Products.Update;
using DtoLayer.CategoryDto;
using DtoLayer.ProductDto;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
	public interface IProductService 
	{
		Task<ServiceResult<ProductDto?>> GetByIDAsync(int id);
		Task<ServiceResult<List<ProductDto>>> GetListAsync();

		Task<ServiceResult<CreateProductResponse>> InsertAsync(CreateProductRequest request);
		Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request);
		Task<ServiceResult> DeleteAsync(int id);
	}
}
