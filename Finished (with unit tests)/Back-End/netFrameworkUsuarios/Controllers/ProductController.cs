using Management.Data;
using Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace netFrameworkUsuarios.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet, Route("api/getProducts")]
        public dynamic getProducts()
        {
            try
            {
                return DaoProducts.Instance.getProducts();
              
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }

        }
        [HttpPost, Route("api/buyProducts")]
        public dynamic buyProducts([FromBody] List<Product> products)
        {
            try
            {
                for (int i=0;i< products.Count;i++)
                {
                    DaoProducts.Instance.buyProducts(products[i]);
                    if (products.Count-i==1)
                    {
                        return true;
                    }
                }
                return true;

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }

        }
    }
}
