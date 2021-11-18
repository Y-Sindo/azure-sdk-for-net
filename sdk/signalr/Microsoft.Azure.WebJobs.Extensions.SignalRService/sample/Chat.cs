using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;

namespace sample
{
    public class Chat : ServerlessHub<IChatService>
    {
        [FunctionName("negotiate")]
        public Task<SignalRConnectionInfo> Negotiate([HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req)
        {
            return NegotiateAsync(new NegotiationOptions()
            {
                UserId = "a"
            });
        }

        [FunctionName("send")]
        public async Task Send([HttpTrigger(AuthorizationLevel.Anonymous)] HttpRequest req, ILogger logger)
        {
            await UserGroups.AddToGroupAsync("abc", "group");
            logger.LogInformation($"{await ClientManager.GroupExistsAsync("abc")}");
            await Clients.All.SendMessage("abc");
        }
    }

    public interface IChatService
    {
        Task SendMessage(string message);
    }
}
