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
    public class UserController : ApiController
    {
        [HttpPost, Route("api/login")]
        public dynamic buyProducts([FromBody]User User)
        {
            try
            {
                return DaoUsers.Instance.login(User);
                
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }

        }
    }
}
