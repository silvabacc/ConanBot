using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace DSPiggy.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task helpme()
        {
            await ReplyAsync("What a fucking noob, doesn't even know how to use DSPiggy...\n\nsnort update - get the latest tweet from Laughing Archieves\n\nsnort donate - donate to piggy's patreon for quality khantent\n\nsnort tweet - get a fucking tweet");
        }
    }
}
