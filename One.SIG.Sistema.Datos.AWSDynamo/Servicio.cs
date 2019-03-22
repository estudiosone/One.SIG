using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.SIG.Sistema.Datos.AWSDynamo
{
    public class Servicio
    {
        public static Servicio Current { get; private set; }
        private AmazonDynamoDBClient Cliente { get; set; }

        public Servicio()
        {
            Current = this;
        }

        private void IniciarCliente(string awsAccessKeyId, string awsSecretAccessKey, RegionEndpoint region)
        {
            Cliente = new AmazonDynamoDBClient(awsAccessKeyId, awsSecretAccessKey, region);
        }

        private async void IniciarTablas()
        {
            var TablasCreadas = (await Cliente.ListTablesAsync()).TableNames;
        }

        private async void CrearTabla()
        {
            var solicitud = new CreateTableRequest()
            {
                TableName=nombre, KeySchema=new List<KeySchemaElement>()
                {
                   new KeySchemaElement("Id", KeyType.)
                }
            }
            Cliente.CreateTableAsync(new CreateTableRequest())
        }
    }
}
