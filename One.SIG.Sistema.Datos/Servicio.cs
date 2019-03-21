using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.SIG.Sistema.Datos
{

    public class Servicio
    {
        /// <summary>
        /// Servicio de manejo de datos
        /// </summary>
        public Servicio()
        {
            Current = this;
        }
        public static Servicio Current { get; private set; }
    }


}
