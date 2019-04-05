using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.SIG.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            //        int selectedClass = Menu.MultipleChoice(true, "Warrior", "Bard", "Mage", "Archer",
            //"Thief", "Assassin", "Cleric", "Paladin", "etc.");

            var awsAccessKeyId = "AKIAIN7WGGIWGI5LLMJA";
            var awsSecretAccessKey = "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";

            //var body =
            //    "<div>" +
            //    "   Buenos días, Diego" +
            //    "   <br>" +
            //    "   ¡El motivo de mi contacto es ofrecerle una promoción imperdible!" +
            //    "   <br>" +
            //    "   <img style=\"max - width:100 %; display: inline - block\" src=\"http://www.livebeep.com/visitor/medias/file/image/large/163/p/Promo-Turismo-feed-jpg-210226.jpg\">" +
            //    "</div>";
            var client = new Amazon.SimpleEmail.AmazonSimpleEmailServiceClient(awsAccessKeyId, awsSecretAccessKey, Amazon.RegionEndpoint.USEast1);

            var createTemplateResponse = client.CreateTemplate(
                new Amazon.SimpleEmail.Model.CreateTemplateRequest()
                {
                    Template = new Amazon.SimpleEmail.Model.Template()
                    {
                        TemplateName = "T001",
                        SubjectPart = "Promoción de prueba",
                        HtmlPart =
                        "<div>" +
                        "   Buenos días, {{name}}!" +
                        "   <br>" +
                        "   ¡El motivo de mi contacto es ofrecerle una promoción imperdible!" +
                        "   <br>" +
                        "   <img style=\"max - width:100 %; display: inline - block\" src=\"http://www.livebeep.com/visitor/medias/file/image/large/163/p/Promo-Turismo-feed-jpg-210226.jpg\">" +
                        "</div>"
                    }
                });


            var sendBulkTemplatedEmailResponse = client.SendBulkTemplatedEmail(new Amazon.SimpleEmail.Model.SendBulkTemplatedEmailRequest()
            {
                ConfigurationSetName = "Marketing",
                Destinations = new List<Amazon.SimpleEmail.Model.BulkEmailDestination>()
                {
                    new Amazon.SimpleEmail.Model.BulkEmailDestination()
                    {
                         Destination = new Amazon.SimpleEmail.Model.Destination(new List<string>(){ "tecnica@eldescubrimiento.com" }),
                         ReplacementTemplateData = "{\"name\":\"Diego\"}"
                    },
                    new Amazon.SimpleEmail.Model.BulkEmailDestination()
                    {
                         Destination = new Amazon.SimpleEmail.Model.Destination(new List<string>(){ "diegorrod91@gmail.com" }),
                         ReplacementTemplateData = "{\"name\":\"Diego Rodríguez\"}"
                    }
                },
                Source = "El Descubrimiento RESORT CLUB <noreplay@eldescubrimiento.com>",
                ReplyToAddresses = new List<string> { "El Descubrimiento RESORT CLUB <info@eldescubrimiento.com>" },
                Template = "T001",
                DefaultTemplateData = "{\"name\":\"estimado cliente\"}"
            });

            var deleteTemplateResponse = client.DeleteTemplate(new Amazon.SimpleEmail.Model.DeleteTemplateRequest()
            {
                TemplateName = "T001",
            });

            //var result = client.SendEmail(new Amazon.SimpleEmail.Model.SendEmailRequest()
            //{
            //    Source = "El Descubrimiento RESORT CLUB <noreplay@eldescubrimiento.com>",
            //    ReplyToAddresses = new List<string> { "El Descubrimiento RESORT CLUB <info@eldescubrimiento.com>" },
            //    Destination = new Amazon.SimpleEmail.Model.Destination()
            //    {
            //        ToAddresses = new List<string>()
            //        {
            //              "tecnica@eldescubrimiento.com"
            //        }
            //    },
            //    Message = new Amazon.SimpleEmail.Model.Message()
            //    {
            //        Subject = new Amazon.SimpleEmail.Model.Content("Prueba"),
            //        Body = new Amazon.SimpleEmail.Model.Body()
            //        {
            //            Html = new Amazon.SimpleEmail.Model.Content(body)
            //        }
            //    },
            //    ConfigurationSetName = "Marketing",
            //});
            //Console.WriteLine(result.MessageId);
            //Console.ReadKey();
        }
    }
}
