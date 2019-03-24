using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.SIG.Sistema.Datos.AWSDynamoDB.Model
{
    [DynamoDBTable("Marketing.Campaign.Mail")]
    public class MarketingCampañaMail
    {
        [DynamoDBHashKey("Id")]
        public string Id { get; set; }
        [DynamoDBProperty("Campaign")]
        public string Campaña { get; set; }
        [DynamoDBProperty("FromAdress")]
        public string DireccionEnvio { get; set; }
        [DynamoDBProperty("Subject")]
        public string Asunto { get; set; }
        [DynamoDBProperty("Body")]
        public string Cuerpo { get; set; }
    }
}
