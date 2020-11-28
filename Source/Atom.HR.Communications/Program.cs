using Nexmo.Api;
using System;

namespace Atom.HR.Communications
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = "42b78bc4",
                ApiSecret = "Ze59JrtW8fePjpgW"
            });
            var results = client.SMS.Send(request: new SMS.SMSRequest
            {
                from = "Vonage APIs",
                to = "79105971343",
                text = "Hello from Atom! Peaceful Atom!"
            });
        }
    }
}
