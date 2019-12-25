using System.Threading.Tasks;
using Discord.Commands;

namespace DSPiggy.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task helpme()
        {
            await ReplyAsync("Bot Commands:...\n\nconan update - get the latest tweet from Conan's twitter\n\nconan tweet - get a random tweet from Conan's twitter\n\nconan joke - ConanBot will go into a voice channel and tell a Conan joke");
        }
    }
}
