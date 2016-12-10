using SMart.Data;
using SMart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMart.Business
{
    public class ProductRepository : IProductRepository
    {
        private IProductDL _productdal;

        public ProductRepository(IProductDL productdl)
        {
            _productdal = productdl;
        }

        public Product SaveProduct(Product product)
        {
            return _productdal.SaveProduct(product);
        }
    }
}