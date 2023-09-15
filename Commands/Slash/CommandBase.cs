using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.ComponentModel.Design;

namespace MainBot.Commands.Slash {
    public class CommandBase {

        public CommandBase(MainBot.Socket.Client client, SocketGuild guild) {
            CreateCommands(client, guild);
        }

        private async void CreateCommands(MainBot.Socket.Client client, SocketGuild guild) {

            IReadOnlyCollection<SocketApplicationCommand> cmd = await client.GetGlobalApplicationCommandsAsync();
            if (cmd.Count != 0 ) {
                foreach (SocketApplicationCommand item in cmd) {
                    await item.DeleteAsync();
                }
            }
            List<SlashCommandBuilder> slashcmds = new List<SlashCommandBuilder>();

            slashcmds.Add(await basedCmd());

            foreach (SlashCommandBuilder command in slashcmds) {
                await client.CreateGlobalApplicationCommandAsync(command.Build());
            }
        }

        private async Task<SlashCommandBuilder> basedCmd() {
            SlashCommandBuilder commandBuilder = new SlashCommandBuilder();

            commandBuilder.WithName("creator");
            commandBuilder.WithDescription("the creators github https://github.com/Leondias-sudo");

            return commandBuilder;
        }
    }
}
