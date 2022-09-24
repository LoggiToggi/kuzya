using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace qqqq
{ 
    class Progam
    { 
        DiscordSocketClient? client;
        static void Main(string[] args) => new Progam().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandsHandler;
            client.Log += Log;

            var token = "MTAyMTQ0MjAyNjI5MTU5MzMxOA.GbMMyN.5-deDK4NZdwhXoI7wuy5_D-u9vAta4pTOUal6M";

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            Console.ReadLine();
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandsHandler(SocketMessage msg)
        {
            if (!msg.Author.IsBot)
                switch (msg.Content)
                {
                    case "!Кузя":
                        {
                            msg.Channel.SendMessageAsync($"пр..привет, {msg.Author}");
                            break;
                        }
                }
            return Task.CompletedTask;
        }
    }
}