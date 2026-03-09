using DataAccessLayer.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Products.Create
{
	public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
	{
		private readonly IProductDal _productdal;


		public CreateProductRequestValidator(IProductDal productDal)
		{
			_productdal = productDal;
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Ürün İsmi Gereklidir.")
				.Length(3, 10).WithMessage("Ürün İsmi 3 ile 10 Karakter Arasında Olmalıdır.");			

			RuleFor(x => x.Price)
				.GreaterThan(0).WithMessage("Ürün Fiyatı 0'dan Büyük Olmalıdır.");			
		}
	}
}
