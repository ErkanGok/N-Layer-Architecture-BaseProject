using BusinessLayer.Abstract;
using DtoLayer.CategoryDto;
using DtoLayer.ProductDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductCategoryController : Controller
	{
		private readonly IProductCategoryService _productCategoryService;

		public ProductCategoryController(IProductCategoryService productCategoryService)
		{
			_productCategoryService = productCategoryService;
		}

		[HttpGet("GetListProductCategory")]
		public async Task<IActionResult> GetListProduct()
		{
			var values = await _productCategoryService.GetListAsync();
			var listDto = values.Select(x => new GetListCategoryDto
			{
				ID = x.ID,
				Name = x.Name				
			}).ToList();

			return Ok(listDto);
		}

		[HttpPost("AddCategory")]
		public async Task<IActionResult> AddCategory(AddCategoryDto addCategoryDto)
		{
			var values = new ProductCategory
			{
				Name = addCategoryDto.Name				
			};
			await _productCategoryService.InsertAsync(values);
			return Ok("Kategori Başarıyla Eklendi !");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var values = await _productCategoryService.GetByIDAsync(id);

			if (values == null)
				return NotFound("Kategori bulunamadı!");

			await _productCategoryService.DeleteAsync(values);

			return Ok("Kategori Başarıyla Silindi!");
		}

		[HttpPut("UpdateCategory")]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto productUpdateDto)
		{
			var values = new ProductCategory()
			{
				ID = productUpdateDto.ID,
				Name = productUpdateDto.Name				
			};
			await _productCategoryService.UpdateAsync(values);
			return Ok("Kategori Başarıyla Güncellendi");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIDProduct(int id)
		{
			var value = await _productCategoryService.GetByIDAsync(id);

			if (value == null)
				return NotFound("Ürün bulunamadı!");

			var dto = new GetListCategoryDto
			{
				ID = value.ID,
				Name = value.Name,				

			};

			return Ok(dto);
		}
	}
}
