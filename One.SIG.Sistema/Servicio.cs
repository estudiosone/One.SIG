using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.SIG.Sistema
{
    public class Servicio
    {
        /// <summary>
        /// Servicio de manejo del sistema
        /// </summary>
        public Servicio()
        {
            Current = this;
        }

        public static Servicio Current { get; private set; }
    }
}
