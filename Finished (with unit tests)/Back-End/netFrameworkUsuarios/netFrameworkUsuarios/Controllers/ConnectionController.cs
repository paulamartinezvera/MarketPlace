using Management.Data;
using Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
namespace netFrameworkUsuarios.Controllers
{
   // [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class ConnectionController : ApiController
    {
        [HttpPost, Route("api/AddConnection")]
        public dynamic addConnection([FromBody]Connection connection)
        {
            try
            {
                DaoConnection.Instance.addConnection(connection);
                return Request.CreateResponse(HttpStatusCode.OK, (int)HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }

        }
        [HttpPut, Route("api/UpdateDisconnect")]
        public dynamic updateDisconnect([FromBody]FinalConnection connection)
        {
            long retorno = -1;
            try
            {
                retorno = DaoConnection.Instance.updateDisconnect(connection);
                return retorno;
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }
        }
        [HttpGet, Route("api/GetLastConnection")]
        public dynamic getLastConnection(Int32 IdUsuario)
        {
            try
            {
                return DaoConnection.Instance.getLastConnection(IdUsuario);

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }

        }
        [HttpGet, Route("api/GetConnectionsByIdUsuario")]
        public dynamic getConnectionsByIdUsuario(Int32 IdUsuario)
        {
            try
            {
                return DaoConnection.Instance.getConnectionsByIdUsuario(IdUsuario);

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }

        }
    }
}
