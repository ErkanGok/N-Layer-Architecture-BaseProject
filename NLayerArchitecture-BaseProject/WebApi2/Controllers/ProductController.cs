using BusinessLayer.Abstract;
using DtoLayer.ProductDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		//[HttpGet("GetListProduct")]
		//public async Task<IActionResult> GetListProduct()
		//{
		//	var values = await _productService.GetListAsync();
		//	var listDto = values.Select(x => new AddProductDto
		//	{				
		//		Name = x.Name,
		//		Price = x.Price,
		//		Quantity = x.Quantity,
		//	}).ToList();

		//	return Ok(listDto);
		//}

		[HttpGet("GetListProductwithCategory")]
		public async Task<IActionResult> GetListProductwithCategory()
		{
			var values = await _productService.ProductwithCategoryGetListAsync();
			var listDto = values.Select(x => new GetListProductDto
			{
				ID = x.ID,
				Name = x.Name,
				Price = x.Price,
				Quantity = x.Quantity,
				
				CategoryName = x.ProductCategory.Name,
			}).ToList();

			return Ok(listDto);
		}

		[HttpPost("AddProduct")]
		public async Task<IActionResult> AddProduct(AddProductDto addProductDto)
		{
			var values = new Product { 
				Name = addProductDto.Name, 
				Price = addProductDto.Price,
				Quantity = addProductDto.Quantity,
				ProductCategoryID = addProductDto.ProductCategoryID,
			};
			 await _productService.InsertAsync(values);
			return Ok("Ürün Başarıyla Eklendi !");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var values = await _productService.GetByIDAsync(id);

			if (values == null)
				return NotFound("Ürün bulunamadı!");

			await _productService.DeleteAsync(values);

			return Ok("Ürün Başarıyla Silindi!");
		}

		[HttpPut("UpdateProduct")]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto productUpdateDto)
		{
			var values = new Product()
			{
				ID = productUpdateDto.ID,
				Name = productUpdateDto.Name,
				Price = productUpdateDto.Price,
				Quantity = productUpdateDto.Quantity,
				ProductCategoryID = productUpdateDto.ProductCategoryID,
			};
			 await _productService.UpdateAsync(values);
			return Ok("Ürün Başarıyla Güncellendi");
		}
		//[HttpGet("{id}")]
		//public async Task<IActionResult> GetByIDProduct(int id)
		//{
		//	var value = await _productService.GetByIDAsync(id);

		//	if (value == null)
		//		return NotFound("Ürün bulunamadı!");

		//	var dto = new AddProductDto
		//	{				
		//		Name = value.Name,
		//		Price = value.Price,
		//		Quantity = value.Quantity,

		//	};

		//	return Ok(dto);
		//}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIDProduct(int id)
		{
			var value = await _productService.ProductwithCategoryGetByIDAsync(id);

			if (value == null)
				return NotFound("Ürün bulunamadı!");

			var dto = new GetListProductDto
			{
				ID	= value.ID,
				Name = value.Name,
				Price = value.Price,
				Quantity = value.Quantity,
				CategoryName = value.ProductCategory.Name,

			};

			return Ok(dto);
		}
	}
}
