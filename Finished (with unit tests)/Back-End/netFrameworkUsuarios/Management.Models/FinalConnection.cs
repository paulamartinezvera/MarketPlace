using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Models
{
    public class FinalConnection
    {
        public DateTime fechaConexion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? fechaDesconexion { get; set; }
        
    }
}
