using SMart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMart.Data
{
    public interface IProductDL
    {
        Product SaveProduct(Product product);
    }
}
