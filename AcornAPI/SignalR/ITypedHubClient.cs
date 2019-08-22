using System.Threading.Tasks;

namespace AcornAPI.SignalR
{
    public interface ITypedHubClient
    {
        Task BotUpdate(string type, string payload);
        Task AccountUpdate(string type, string payload);
    }
}
