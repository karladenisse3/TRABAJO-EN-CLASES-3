using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioClientes.Clases
{
    public class Factura
    {

        public string Observacion { get; set; }
        public int  Identificacion { get; set; }
        public DateTime fecha { get; set; }
        public double Total { get; set; }
        
    }
}
