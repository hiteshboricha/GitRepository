using SMart.Business;
using SMart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SMart.Controllers
{
    public class ProductController : ApiController
    {
        private IProductBL _productbusiness;

        // POST: api/Product
        public Product Get()
        {
            Product product = new Product();
            product.Id = 1;
            product.Name = "Ice-cream";

            _productbusiness = new ProductBL();

            var response = _productbusiness.SaveProduct(product);

            return Json<Product>(response).Content;
        }

        #region TODO
        //// GET: api/Product
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Product/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// PUT: api/Product/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Product/5
        //public void Delete(int id)
        //{
        //}
        #endregion
        
    }
}
