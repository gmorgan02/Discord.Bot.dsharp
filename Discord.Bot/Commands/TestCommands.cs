using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace Discord.Bot.Commands
{
    public class TestCommands
    {
        [Command("ping")]
        [Description("Returns pong")]
        public async Task Ping(CommandContext ctx)
        {
            var content = "pong";
            await ctx.Channel.SendMessageAsync(content).ConfigureAwait(false);
        }

        [Command("add")]
        [Description("Adds two numbers together")]
        public async Task Add(CommandContext ctx, [Description("The first number to add")] int firstNumber, [Description("The second number to add")] int secondNumber)
        {
            await ctx.Channel
                .SendMessageAsync((firstNumber + secondNumber).ToString())
                .ConfigureAwait(false);
        }
    }
}
