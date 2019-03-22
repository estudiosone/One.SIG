using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.SIG.Sistema.Datos.Modelo
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreSegundo { get; set; }
        public string Apellido { get; set; }
        public string ApellidoSegundo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad
        {
            get
            {
                var a = DateTime.Now - FechaNacimiento;
                return Convert.ToInt32(a.Days / 365);
            }
        }
        public string TipoDeDocumento { get; set; }
        public string Documento { get; set; }
    }
}
