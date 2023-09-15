using Discord.Commands;
using Discord;
using MainBot.Interfaces;
using Discord.WebSocket;

namespace MainBot.Socket {
    public struct Config {
        public string? Token { get; set; }

        public ILogger Logger { get; set; }

        public TokenType TokenType { get; set; }

        public IServiceProvider ServiceProvider { get; set; }

        public CommandService Commands { get; set; }

        public char CustomPrefixChar {get; set; }

        public string CustomPrefixString { get; set; }

        public long GuilID;

        public DiscordSocketConfig socketConfig { get; set; }
    }
}
