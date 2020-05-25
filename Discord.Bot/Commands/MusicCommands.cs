using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace Discord.Bot.Commands
{
    public class MusicCommands : BaseCommandModule
    {
        

        [Command("play")]
        [Description("Plays Music")]
        public async Task Play(CommandContext ctx, [Description("URL to the song you wish to play")] string songUrl)
        {
            if (string.IsNullOrEmpty(songUrl))
            {                
                await ctx.Channel.SendMessageAsync("Url is not provided.").ConfigureAwait(false);
            }

            if (ctx.Member.VoiceState == null)
            {
                await ctx.Channel.SendMessageAsync("Url is not provided.").ConfigureAwait(false);
            }
        }
    }
}
