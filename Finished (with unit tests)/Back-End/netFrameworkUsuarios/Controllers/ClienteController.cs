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
    public class ClienteController : ApiController
    {
        [Authorize]
        [HttpPost, Route("api/InsertarMetas")]
        public dynamic insertarMetas(List<Metas> metas)
        {
            try
            {
                if (metas != null)
                {
                    if (metas.Count == 1)
                    {
                        return DaoCliente.Instance.insertaMetas(metas[0]);
                    }
                }

                return null;
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }

        }
    }
}
