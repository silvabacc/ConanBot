
using System;   
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Audio;
using Discord;
using Discord.Commands;
using Discord.Audio;
using Discord.WebSocket;
using NAudio;
using NAudio.Wave;

namespace DSPiggy.Modules{
    public class Audio : ModuleBase<SocketCommandContext>{
        
        private SocketGuildUser user;
        private static CancellationTokenSource cancellationToken = new CancellationTokenSource();
        /*

        private ISocketAudioChannel channel;

        private static string mytoken = "";
        private static bool playing = false;
        private static AudioOutStream dstream = null;
        private static IAudioClient client = null;
        */

        private static string mytoken = "";
        private static bool playing = false;
        private ISocketAudioChannel channel;
        private static AudioOutStream dstream = null;
        private static IAudioClient client = null;


        //private static CancellationTokenSource cancellationToken = new CancellationTokenSource();

        [Command("laugh", RunMode = RunMode.Async)]

        public async Task JoinAudio(){
            
            var Client = Program._client;

            user = Context.User as SocketGuildUser;
            channel = user.VoiceChannel;

            string path = "laugh.mp3";

            var guild = Client.Guilds.First();
            
            try
            {
                user = Context.User as SocketGuildUser;
                if (user.VoiceState == null)
                {
                    await Context.Channel.SendMessageAsync(":x: ACK ACK ACK You aint' in a voice channel STOOPID!");
                    return;
                }
                if(client == null){client = await channel.ConnectAsync();}
                

                var reader = new Mp3FileReader(path);
                var naudio = WaveFormatConversionStream.CreatePcmStream(reader);

                dstream = client.CreatePCMStream(AudioApplication.Music);
                byte[] buffer = new byte[naudio.Length];

                int rest = (int)(naudio.Length - naudio.Position);
                await naudio.ReadAsync(buffer, 0, rest);
                playing = true;
                await dstream.WriteAsync(buffer, 0, rest, cancellationToken.Token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if(e.InnerException != null)
                    Console.WriteLine(e.InnerException.Message);
                    return;
            }

        while (!playing) ;
        Console.ReadLine();
        cancellationToken.Cancel();
        Debug.WriteLine("Pre-Flush");
        dstream.Flush();
        Debug.WriteLine("POST-FLUSH");
        client.StopAsync().Wait();

        Client.StopAsync().Wait();
        Client.LogoutAsync().Wait();
    }
            /* 
            user = Context.User as SocketGuildUser;
            if (user.VoiceState == null)
            {
                await Context.Channel.SendMessageAsync(":x: You aint' in a voice channel!");
                return;
            }

            string path = "laugh.mp3";

            channel = user.VoiceChannel;
            await channel.ConnectAsync();*/

        }
}
    

    
