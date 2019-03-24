using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.SIG.Sistema.Datos.AWSDynamoDB
{
    public class Servicio
    {
        private AmazonDynamoDBClient Cliente { get; set; }

        public Servicio()
        {
            var awsAccessKeyId = "AKIAIN7WGGIWGI5LLMJA";
            var awsSecretAccessKey = "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";

            Cliente = new AmazonDynamoDBClient(awsAccessKeyId, awsSecretAccessKey, RegionEndpoint.USEast1);
        }

        public void GenerarTest()
        {
            var tables = Cliente.ListTables().TableNames;
            if(!tables.Exists(x => x == "Marketing.Campaign.Mail"))
            {
                Cliente.CreateTable(
                    new CreateTableRequest(
                        "Marketing.Campaign.Mail", 
                        new List<KeySchemaElement>()
                        {
                            new KeySchemaElement("Id", KeyType.HASH)
                        }));
            }
            DynamoDBContext contexto = new DynamoDBContext(Cliente);
            var a = new Model.MarketingCampañaMail
            {
                Id = Guid.NewGuid().ToString(),
                Asunto = "Test"
            };

            contexto.Save(a);
        }

        private async void VerificarTablas()
        {
            var tablas = new List<string>()
            {
                "Marketing.Campañas",
                "Marketing.Campañas.Envios"
            };

            var tablasCreadas = (await Cliente.ListTablesAsync()).TableNames;

            foreach (var tabla in tablas)
            {
                if(!tablasCreadas.Exists(x => x == tabla))
                {
                    CrearTabla(tabla);
                }
            }
        }
        private async void CrearTabla(string nombre)
        {
            var keySchema = new List<KeySchemaElement>()
            {
                new KeySchemaElement("Id", KeyType.HASH)
            };
            var request = new CreateTableRequest(nombre, keySchema);
            await Cliente.CreateTableAsync(request);
        }
    }
}
