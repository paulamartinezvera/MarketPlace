using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public long? telefono { get; set; }
        public int activo { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public long? cedula { get; set; }
        public int? idRol { get; set; }
        public string campaign { get; set; }
    }
}
