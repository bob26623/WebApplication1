using Azure.Identity;
using Microsoft.Graph.Models;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Graph.Users.Item.SendMail;
using System.Configuration;


namespace WebApplication1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected async void SendMail_Click(object sender, EventArgs e)
        {
            var scopes = new[] { "https://graph.microsoft.com/.default" };

            // Values from app registration
            var clientId = ConfigurationManager.AppSettings["graph:ClientId"];
            var tenantId = ConfigurationManager.AppSettings["graph:TenantId"];
            var clientSecret = ConfigurationManager.AppSettings["graph:ClientSecret"];
            var senderId = ConfigurationManager.AppSettings["graph:SenderId"];
            var replyId = ConfigurationManager.AppSettings["graph:ReplyId"];

            // using Azure.Identity;
            var options = new ClientSecretCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
            };

            var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret, options);

            var graphClient = new GraphServiceClient(clientSecretCredential, scopes);
            var requestBody = new SendMailPostRequestBody
            {
                Message = new Message
                {
                    Subject = "Example email testing",
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Text,
                        Content = message.Text,
                    },
                    ToRecipients = new List<Recipient>
                    {
                        new Recipient
                        {
                            EmailAddress = new EmailAddress
                            {
                                Address = Context.User.Identity.Name,
                            },
                        },
                    },
                    ReplyTo = new List<Recipient>
                    {
                        new Recipient
                        {
                            EmailAddress = new EmailAddress
                            {
                                Address = replyId,
                            },
                        },
                    },
                    From = new Recipient
                    {
                        EmailAddress = new EmailAddress
                        {
                            Address = replyId,
                        },
                    },
                    Sender = new Recipient
                    {
                        EmailAddress = new EmailAddress
                        {
                            Address = replyId,
                        },
                    },
                },
                SaveToSentItems = false,
            };
            await graphClient.Users[senderId].SendMail.PostAsync(requestBody);
        }
    }
}