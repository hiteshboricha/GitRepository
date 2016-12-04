using SMart.Data;
using SMart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMart.Business
{
    public interface IProductBL
    {
        Product SaveProduct(Product product);
    }
}
