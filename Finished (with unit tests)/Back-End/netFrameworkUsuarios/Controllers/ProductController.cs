using Management.Data;
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
                return DaoProducts.Instance.traeCampanaLlamadaManual();
              
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }

        }
    }
}
