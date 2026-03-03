using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.ProductDto
{
	public class AddProductDto
	{
		
		public string Name { get; set; }
		public int Price { get; set; }
		public int Quantity { get; set; }
		public int? ProductCategoryID { get; set; }
	}
}
