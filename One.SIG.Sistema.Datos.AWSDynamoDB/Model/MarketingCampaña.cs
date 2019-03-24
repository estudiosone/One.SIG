using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.SIG.Sistema.Datos.AWSDynamoDB.Model
{
    public class MarketingCampaña
    {
        public string Id { get; set; }
        public string Empresa { get; set; }
        public string Descripcion { get; set; }
        public string MailDesde { get; set; }
        public string MailAsunto { get; set; }
        public string MailCuerpo { get; set; }
        public int MyProperty { get; set; }
        public DateTime Creada { get; set; }
        public string CreadaPor { get; set; }
    }
}
