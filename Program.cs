using Discord.Commands;
using MainBot.Socket;
using MainBot.Commands.CustomPrefix;
using MainBot.Log;
using MainBot.Token;
using Microsoft.Extensions.DependencyInjection;

public class Program {
    [STAThread]
    public static void Main(string[] args) => new Program().StartUp();

    public Task StartUp() {
        Config config = new Config() {
            Logger = new BaseLogger(),

            Token = Token.GetToken,

            TokenType = Discord.TokenType.Bot,

            ServiceProvider = new ServiceCollection().
            AddSingleton<MainBot.Commands.CustomPrefix.CommandBase>(new MainBot.Commands.CustomPrefix.CommandBase())
            .BuildServiceProvider(),

            Commands = new CommandService(),

            GuilID = 952900776676708372,

            socketConfig = new Discord.WebSocket.DiscordSocketConfig() {
                UseInteractionSnowflakeDate = true,
            }
        };
        Client client = new Client(config);
        Waiter(null);
        return Task.CompletedTask;
    }

    private static void Waiter(Client client) { 
        Console.ReadLine();
        Waiter(client);
    }
}