using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace DiscordBotTemplate
{
    class Program
    {
        static DiscordClient discord; //important bot stuff
        static CommandsNextModule commands; //more important bot stuff

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = System.IO.File.ReadAllText(@"TOKEN FILE GOES HERE"),
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "."
            });

            commands.RegisterCommands<MyCommands>();



            await discord.ConnectAsync();

            await Task.Delay(-1);
        }
    }
}
