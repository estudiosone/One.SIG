using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.SIG.Sistema.Datos.Modelo
{
    public class Direccion
    {
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
        public string Calle { get; set; }
        public string Puerta { get; set; }
        public int CodigoPostal { get; set; }
    }
}
