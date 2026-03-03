using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class ProductCategory
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
