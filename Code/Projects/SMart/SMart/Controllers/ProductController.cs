using Microsoft.Practices.Unity;
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
        private IProductRepository _productrepository;

        public ProductController()
        {

        }

        //Constructor Injection example
        public ProductController(IProductRepository productrepo)
        {
            _productrepository = productrepo;
        }

        ////Property Injection example
        //[Dependency]
        //public IProductRepository Repository
        //{
        //    get
        //    {
        //        return _productrepository;
        //    }
        //    set
        //    {
        //        _productrepository = value;
        //    }
        //}

        public Product Get()
        {
            ////Property Injection example
            //var response = Repository.GetProduct();

            //Constructor Injection example
            var response = _productrepository.GetProduct();

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
