using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Models
{
    public class Valores
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public Boolean? MismoAgente { get; set; }
        public Double? CODIGO_INCONCERT { get; set; }
    }
}
