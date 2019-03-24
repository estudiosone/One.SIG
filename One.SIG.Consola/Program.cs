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

            var body =
                "<div>" +
                "   Buenos días, Diego" +
                "   <br>" +
                "   ¡El motivo de mi contacto es ofrecerle una promoción imperdible!" +
                "   <br>" +
                "   <img style=\"max - width:100 %; display: inline - block\" src=\"http://www.livebeep.com/visitor/medias/file/image/large/163/p/Promo-Turismo-feed-jpg-210226.jpg\">" +
                "</div>";
            var client = new Amazon.SimpleEmail.AmazonSimpleEmailServiceClient(awsAccessKeyId, awsSecretAccessKey, Amazon.RegionEndpoint.USEast1);

            var result = client.SendEmail(new Amazon.SimpleEmail.Model.SendEmailRequest()
            {
                Source = "El Descubrimiento RESORT CLUB <noreplay@eldescubrimiento.com>",
                ReplyToAddresses = new List<string> { "El Descubrimiento RESORT CLUB <info@eldescubrimiento.com>" },
                Destination = new Amazon.SimpleEmail.Model.Destination()
                {
                    ToAddresses = new List<string>()
                    {
                          "tecnica@eldescubrimiento.com"
                    }
                },
                Message = new Amazon.SimpleEmail.Model.Message()
                {
                    Subject = new Amazon.SimpleEmail.Model.Content("Prueba"),
                    Body = new Amazon.SimpleEmail.Model.Body()
                    {
                        Html = new Amazon.SimpleEmail.Model.Content(body)
                    }
                }
            });
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
