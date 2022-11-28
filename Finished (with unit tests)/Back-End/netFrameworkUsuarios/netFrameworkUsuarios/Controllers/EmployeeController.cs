
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
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        [HttpGet, Route("api/GetAllEmployees")]
        public dynamic GetAllEmployees()
        {
            try
            {
                return DaoEmployee.Instance.getAllEmployees();

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }

        }
        [HttpPut, Route("api/UpdateEmployeeState")]
        public dynamic updateEmployeeState([FromBody]ActiveEmployee activeEmployee)
        {
            long retorno = -1;
            try
            {
                retorno = DaoEmployee.Instance.updateEmployeeState(activeEmployee);
                return retorno;
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }
        }
    }
}
