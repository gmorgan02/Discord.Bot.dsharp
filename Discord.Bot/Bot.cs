using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Discord.Bot.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.VoiceNext;
using DSharpPlus.VoiceNext.Codec;
using Newtonsoft.Json;

namespace Discord.Bot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextModule Commands { get; private set; }
        public VoiceNextClient Voice { get; set; }

        public async Task RunAsync()
        {
            //reads the config
            var json = string.Empty;

            using(var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };

            Client = new DiscordClient(config);
            var voice = Client.UseVoiceNext();

            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefix =  configJson.Prefix,
                EnableMentionPrefix = true,
                EnableDms = false,
            };

            Commands = Client.UseCommandsNext(commandsConfig);
            //Initializes the commands from each class
            Commands.RegisterCommands<TestCommands>();
            Commands.RegisterCommands<MusicCommands>();

            // let's set up voice
            var vcfg = new VoiceNextConfiguration
            {
                VoiceApplication = VoiceApplication.Music
            };

            // and let's enable it
            Voice = Client.UseVoiceNext(vcfg);

            await Client.ConnectAsync();

            //Makes sure the bot completes its task and stay online
            await Task.Delay(-1);
        }

        private Task OnClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
