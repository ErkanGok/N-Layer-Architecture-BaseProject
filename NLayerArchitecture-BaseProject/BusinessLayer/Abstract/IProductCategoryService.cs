using App.Services;
using BusinessLayer.ProductCategories.Create;
using BusinessLayer.ProductCategories.Update;
using BusinessLayer.Products.Create;
using BusinessLayer.Products.Update;
using DtoLayer.CategoryDto;
using DtoLayer.ProductDto;
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
		 Task<ServiceResult> DeleteAsync(int id);


		 Task<ServiceResult<GetListCategoryDto?>> GetByIDAsync(int id);


		 Task<ServiceResult<List<GetListCategoryDto>>> GetListAsync();


		Task<ServiceResult<CreateProductCategoryResponse>> InsertAsync(CreateProductCategoryRequest request);


		Task<ServiceResult> UpdateAsync(int id, UpdateProductCategoryRequest request);
		
	}
}
