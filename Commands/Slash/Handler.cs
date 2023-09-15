using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainBot.Commands.Slash {
    public class Handler {
        public async Task SlashCommandHandler(SocketSlashCommand cmd) {
            if (cmd.CommandName == "creator") {
                await cmd.RespondAsync("https://i.ytimg.com/vi/Jdg5u_E0Bgo/hqdefault.jpg");
            } else {
                await cmd.RespondAsync("https://i.ytimg.com/vi/Jdg5u_E0Bgo/hqdefault.jpg");
            }
            
        }
    }
}
