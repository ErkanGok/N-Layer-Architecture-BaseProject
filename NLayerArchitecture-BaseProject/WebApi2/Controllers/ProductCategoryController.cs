using App.API.Controllers;
using BusinessLayer.Abstract;
using BusinessLayer.ProductCategories.Create;
using BusinessLayer.ProductCategories.Update;
using BusinessLayer.Products.Create;
using BusinessLayer.Products.Update;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	
	public class ProductCategoryController(IProductCategoryService _productCategoryService) : CustomBaseController
	{		

		[HttpGet("GetListProductCategory")]
		public async Task<IActionResult> GetListProductCategory() => CreateActionResult(await _productCategoryService.GetListAsync());




		[HttpPost("AddCategory")]
		public async Task<IActionResult> AddCategory(CreateProductCategoryRequest request) => CreateActionResult(await _productCategoryService.InsertAsync(request));
		

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id) => CreateActionResult(await _productCategoryService.DeleteAsync(id));
		

		[HttpPut("UpdateCategory")]
		public async Task<IActionResult> UpdateCategory(int id, UpdateProductCategoryRequest request) => CreateActionResult(await _productCategoryService.UpdateAsync(id, request));
		

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIDProduct(int id) => CreateActionResult(await _productCategoryService.GetByIDAsync(id));
		
	}
}
