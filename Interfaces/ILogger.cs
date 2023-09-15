using Discord.WebSocket;

namespace MainBot.Interfaces {
    public interface ILogger {
        Task Log(Discord.LogMessage msg);
        
        Task Log(string msg);

        Task LogMessage(SocketMessage msg);
    }
}
