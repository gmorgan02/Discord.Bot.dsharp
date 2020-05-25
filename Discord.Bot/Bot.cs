using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;

namespace Discord.Bot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            var config = new DiscordConfiguration
            {

            };

            Client = new DiscordClient(config);

            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {

            };

            Commands = Client.UseCommandsNext(commandsConfig);

            await Client.ConnectAsync();

            //Makes sure the bot completes it's task before quitting
            await Task.Delay(1);
        }

        private Task OnClientReady(ReadyEventArgs e)
        {
            return null;
        }
    }
}
