using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Audio;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace DSPiggy
{
    class Program
    {
        public static DiscordSocketClient _client;

        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();
        
        private CommandService _commands;
        private IServiceProvider _services;

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            String botPrefix = "NDUzMjIxMjExODQ2MDgyNTYw.DfcREg.G9BCPNe7F7ZVYtJ_k3qtFoRH4DE";

            //event subscriptions
            _client.Log += Log;

            await RegisterCommandsAysnc();

            await _client.LoginAsync(TokenType.Bot, botPrefix);

            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAysnc()
        {
            _client.MessageReceived += HandleCommandAsync;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;


            if (message is null || message.Author.IsBot)
            {
                return;
            }

            int argPos = 0;

            if (message.HasStringPrefix(("snort "), ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(_client, message);

                var result = await _commands.ExecuteAsync(context, argPos, _services);

                if (!(result.IsSuccess))
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
		}
	}
}

