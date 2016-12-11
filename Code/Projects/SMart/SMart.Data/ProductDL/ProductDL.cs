using SMart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMart.Data
{
    public class ProductDL : IProductDL
    {
        public Product GetProduct()
        {
            Product product = new Product();
            product.Id = 1;
            product.Name = "Ice-cream";

            return product;
        }
    }
}
