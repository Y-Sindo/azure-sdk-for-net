using System.Threading.Tasks;

namespace FunctionApp
{
    public interface IChatClient
    {
        public Task newMessage(NewMessage message);
        public Task newConnection(NewConnection connection);
    }
}
