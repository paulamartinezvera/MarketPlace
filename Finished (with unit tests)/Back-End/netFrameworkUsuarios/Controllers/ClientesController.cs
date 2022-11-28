using Management.Data;
using Management.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace netFrameworkUsuarios.Controllers
{
    public class ClientesController : ApiController
    {
        [Authorize]
        [HttpPost, Route("api/traeInformacionClientes")]
        public dynamic traeClientes([FromBody] FiltroCliente filtroCliente)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<List<IdentificacionClienteClaro>>(filtroCliente.listaClientes);
                var initialResult = new List<Clientes>();
                var result2 = new List<Clientes>();
                IEnumerable<Clientes> resultEnumerable = null;
                for (var i = 0; i < model.Count; i++)
                {
                    if (i == 0)
                    {
                        resultEnumerable = DaoClientes.Instance.traeClientes(filtroCliente, model[i].IdCliente);
                    }
                    else
                    {
                        initialResult = DaoClientes.Instance.traeClientes(filtroCliente, model[i].IdCliente);
                        resultEnumerable = resultEnumerable.Concat(initialResult);
                    }

                }
                List<Clientes> result = resultEnumerable.ToList();
                return result;
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }

        }
        [Authorize]
        [HttpGet, Route("api/traeCampanaLlamadaManual")]
        public dynamic traeCampanaLlamadaManual()
        {
            try
            {
                var result = new List<Venta>();
                var result2 = new List<Venta>();
                IEnumerable<Valores> finalResult = null;
                var respuesta = DaoClientes.Instance.traeCampanaLlamadaManual();
                finalResult = respuesta;
                /*var respuesta2 = DaoVenta.Instance.traeVentasFiltradas(subEstadoVentaEspecifica);
                finalResult = finalResult.Concat(respuesta2);*/

                return finalResult;
                //return respuesta;
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError + " - " + e.Message.ToString());
            }

        }
    }
}
