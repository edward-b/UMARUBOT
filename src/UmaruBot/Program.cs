using System;
using DSharpPlus;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.Net.WebSocket;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.VoiceNext;

namespace UmaruBot
{
    public class Program
    {
        static DiscordClient discord;
        static CommandsNextModule commands;
        static VoiceNextClient voice;
        static InteractivityModule interactivity;

        public static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = "token here",
                TokenType = TokenType.Bot, 
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            commands = discord.UseCommandsNext(new CommandsNextConfiguration
            {
                StringPrefix = "~"
            });

            commands.RegisterCommands<Commands>();

            interactivity = discord.UseInteractivity(new InteractivityConfiguration());

            voice = discord.UseVoiceNext();

            discord.SetWebSocketClient<WebSocket4NetCoreClient>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
