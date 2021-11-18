using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;

namespace sample
{
    public static class SignalRFunctions
    {
        [FunctionName("SignalRFunctions")]
        [return: SignalR(HubName = "Hub")]
        public static SignalRMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            return new SignalRMessage()
            {
                Arguments = new object[] {
                    new
                    {
                        Name = "me",
                        Location = DateTime.Now
                    }
                },
                Target = "SendMessages"
            };

        }
    }
}
