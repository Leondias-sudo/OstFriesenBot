using Discord;
using Discord.Commands;
using Discord.WebSocket;
using MainBot.Interfaces;
using System.Reflection;

namespace MainBot.Socket {
    public class Client : DiscordSocketClient, IDisposable {

        private Config _config;

        public Client(Config config) :
            base(config.socketConfig) {

            _config = config;

            StartUp();
        }

        public async void StartUp() {

            Log += _config.Logger.Log;

            await SetStatusAsync(UserStatus.DoNotDisturb);

            await LoginAsync(_config.TokenType,
                             _config.Token);

            _config.Token = null;

            await StartAsync();

            SlashCommandExecuted += new Commands.Slash.Handler().SlashCommandHandler;

            MessageReceived += MessageHandler;

            Ready += BotReady;
        }

        public async Task BotReady() {

            SocketGuild guild = GetGuild((ulong)_config.GuilID);

            await _config.Commands.AddModulesAsync(Assembly.GetEntryAssembly(),
                                                   _config.ServiceProvider);

            BuildSlashCommands();

            MessageReceived += Reply;
            await SetStatusAsync(UserStatus.Online);
        }

        public async Task Reply(SocketMessage msg) {
            if (msg != null) {
                SocketUserMessage message = (SocketUserMessage)msg;

                int commandPosition = 0;

                if (message.HasCharPrefix(_config.CustomPrefixChar,
                                          ref commandPosition)) {

                    SocketCommandContext context = new SocketCommandContext(this,
                                                                            message);

                    IResult result = await _config.Commands.ExecuteAsync(context,
                                                                         commandPosition,
                                                                         _config.ServiceProvider);

                    if (result != null) {
                        _config.Logger.Log("Error");
                    }

                }
                else if (message.HasStringPrefix(_config.CustomPrefixString,
                                                  ref commandPosition)) {
                    SocketCommandContext context = new SocketCommandContext(this,
                                                                            message);

                    IResult result = await _config.Commands.ExecuteAsync(context,
                                                                         commandPosition,
                                                                         _config.ServiceProvider);

                    if (result != null) {
                        _config.Logger.Log("Error");
                    }
                }
            }
        }

        private async void BuildSlashCommands() {
            SocketGuild guild = GetGuild(952900776676708372);

            await guild.DeleteApplicationCommandsAsync();

            _ = new MainBot.Commands.Slash.CommandBase(this, guild);
        }

        private async Task MessageHandler(SocketMessage msg) {
            try {
                _config.Logger.LogMessage(msg);
            } catch (Exception ex) {
                await _config.Logger.Log(ex.Message);
            }
            
        }
    }
}