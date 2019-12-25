using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace DSPiggy.Modules
{
    public class Donate : ModuleBase<SocketCommandContext>
    {
        [Command("donate")]
        public async Task patreonDonator()
        {
            Random roller = new Random();
            int roll = roller.Next(0, 100);
            await ReplyAsync("*OINK OINK* you just donated $"+roll+" to my patreon! *SNORT SNORT*");
        }
    }
}
