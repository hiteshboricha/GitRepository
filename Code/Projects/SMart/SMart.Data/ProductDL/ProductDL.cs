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
        public Product SaveProduct(Product product)
        {
            return product;
        }
    }
}
