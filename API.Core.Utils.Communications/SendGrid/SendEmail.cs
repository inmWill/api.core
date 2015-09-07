using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;
using API.Core.Utils.Communications.Interfaces;
using SendGrid;

namespace ConSova.Utils.Communications.SendGrid
{
    public class CoreEmail : ICoreEmail
    {

     //   private const string Username = "azure_349ac0351027c1230ee266e1d66ee395@azure.com";
     //   private const string Pswd = "jSyd6W3hb7fqyfS";
        private string _host = "";
        private string _username = "";
        private string _password = "";
        private readonly NetworkCredential _credentials;

        public CoreEmail()
        {
            _host = WebConfigurationManager.AppSettings["SMTPHost"];
            _username = WebConfigurationManager.AppSettings["SMTPUsername"];
            _password = WebConfigurationManager.AppSettings["SMTPPassword"];
            _credentials = new NetworkCredential(_username, _password);
            
        }

        public bool Send()
        {
            
            


            // Create the email object first, then add the properties.
            var myMessage = new SendGridMessage {From = new MailAddress("Support@ConSova.com")};

            // Add the message properties.

            // Add multiple addresses to the To field.
            var recipients = new List<String>
            {
                @"W Thomas <wthomas@consova.com>",
                @"Will Thomas <wthomas@inmerge.com>"
            };

            myMessage.AddTo(recipients);

            myMessage.Subject = "Testing the SendGrid Library";

            //Add the HTML and Text bodies
            myMessage.Html = "<p>Hello World!</p>";
            myMessage.Text = "Hello World plain text!";

            // Create an Web transport for sending email.
            var transportWeb = new Web(_credentials);

            // Send the email.
            // You can also use the **DeliverAsync** method, which returns an awaitable task.
            transportWeb.Deliver(myMessage);
            return true;
        }

    }
}
