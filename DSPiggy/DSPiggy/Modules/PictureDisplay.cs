using System;   
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using TweetSharp;
using System.Linq;
using System.Collections;
using NReco.ImageGenerator;

namespace DSPiggy.Modules
{
    public class PictureDisplay : ModuleBase<SocketCommandContext>{
        public PictureDisplay(){

        }

        [Command("jackoff")]
        public async Task Jackoff(){
            string html = String.Format(" <img src='/home/bn/Documents/Files/projects/DSPiggy/images of oinky/dance.gif'/>");
            var converter = new HtmlToImageConverter
            {
                Width = 250,
                Height = 700
            };

            var jpgBytes = converter.GenerateImage(html, NReco.ImageGenerator.ImageFormat.Jpeg);
            await Context.Channel.SendFileAsync(new MemoryStream(jpgBytes), "/home/bn/Documents/Files/projects/DSPiggy/images of oinky/dance.gif");
        }

        [Command("dance")]
        public async Task dance(){
            await ReplyAsync("https://redirect.media.tumblr.com/image?url=/a91af9da993970dcf51511e4513a9338/tumblr_pfo9nldEl61xc18kyo1_250.gif");
        }
    }
}
