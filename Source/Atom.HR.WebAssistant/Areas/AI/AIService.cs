using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Atom.HR.WebAssistant.Areas.AI
{
    public class AIService
    {
        static readonly HttpClient client = new HttpClient();
        public async Task<string> GetSpecialization(string skills)
        {
            HttpResponseMessage response = await client.GetAsync($@"https://skilltospecialization.azurewebsites.net/api/HttpTrigger1/?area_id=1&skills=""{skills}""");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            // Above three lines can be replaced with new helper method below
            // string responseBody = await client.GetStringAsync(uri);
            return responseBody;
        }
        public async Task<string> GetPrice(string spec)
        {
            var nespec = spec.Trim('[').Trim(']').Trim('\'').Replace(",","");
            HttpResponseMessage response = await client.GetAsync($@"https://zarplata.azurewebsites.net/api/HttpTrigger1?spec_param=""{nespec}""");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
