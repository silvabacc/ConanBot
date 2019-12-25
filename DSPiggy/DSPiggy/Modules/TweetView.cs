using System;   
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using TweetSharp;
using System.Linq;
using System.Collections;

namespace DSPiggy.Modules
{
    public class TweetView : ModuleBase<SocketCommandContext>
    {
        private static string customer_key = "bhzPBcWQCMzYhN87Zsy3AkvBO";
        private static string customer_key_secret = "uqhVNYx0BEvvMdA0SZhzOn3wufLHNw6exQtcvEUDSPIKdBIbqW";
        private static string access_token = "4004179103-n1I7XyWXzhr73V2fhOfqaQNiCp9oGAhjU4gxWTR";
        private static string access_token_secret = "svGSXSKCqpVJ089uvhJx1jjusgGGJIz5Jj2ttltvkg4RM";

        public TweetView()
        {
            customer_key = "bhzPBcWQCMzYhN87Zsy3AkvBO";
            customer_key_secret = "uqhVNYx0BEvvMdA0SZhzOn3wufLHNw6exQtcvEUDSPIKdBIbqW";
            access_token = "4004179103-n1I7XyWXzhr73V2fhOfqaQNiCp9oGAhjU4gxWTR";
            access_token_secret = "svGSXSKCqpVJ089uvhJx1jjusgGGJIz5Jj2ttltvkg4RM";
        }

        [Command("tweet")]
        public async Task TweetRandom()
        {
            var service = new TwitterService(customer_key, customer_key_secret);
            service.AuthenticateWith(access_token, access_token_secret);

            var koptions = new ListTweetsOnUserTimelineOptions { ScreenName = "DSPArchives" };
            List <long> totalID = new List<long>();
            long checker = 2;
            
            foreach (var tweet in service.ListTweetsOnUserTimeline(koptions))
            {
                long statusID = tweet.Id;
                checker = tweet.Id;
                totalID.Add(statusID);
                Console.WriteLine("THIS IS ID: " + statusID);
            }
            Console.WriteLine("THIS IS TOTAL AMOUNT: " + totalID.Count);
            Random roll = new Random();
            int statusToOut = roll.Next(0, totalID.Count);
            Console.WriteLine("STATUS NUMBER TO BE POSTED: " + statusToOut);

            var tweetToOut = totalID[statusToOut];
            Console.WriteLine("STATUS ID TO BE POSTED: " + tweetToOut);

            if(totalID.Count == 1){
                if(tweetToOut == 0){
                    await ReplyAsync("OINK OINK I gave you 10 years of khantent, gimme a BREAK!");
                }
            }
            else if(tweetToOut == 0){
                await ReplyAsync("OINK OINK Here's your tweet");
                Random rollAgain = new Random();
                int statusToOutAgain = rollAgain.Next(0, totalID.Count-1);
                Console.WriteLine("STATUS NUMBER TO BE RE-POSTED: " + statusToOutAgain);

                var tweetToOutAgain = totalID[statusToOutAgain];
                Console.WriteLine("STATUS ID TO BE POSTED: " + tweetToOutAgain);
                await ReplyAsync("https://twitter.com/DSPArchives/status/" + tweetToOutAgain);
            }
            else{
                await ReplyAsync("https://twitter.com/DSPArchives/status/" + tweetToOut);
            }
        }

        [Command("update")]
        public async Task LatestTweet()
        {
            var service = new TwitterService(customer_key, customer_key_secret);
            service.AuthenticateWith(access_token, access_token_secret);

            var koptions = new ListTweetsOnUserTimelineOptions { ScreenName = "Drgnkiller" };
            string statusID = "";
            foreach (var tweet in service.ListTweetsOnUserTimeline(koptions))
            {
                statusID = tweet.IdStr;
                break;
            }

            Random roller = new Random();
            await ReplyAsync("https://twitter.com/Drgnkiller/status/" + statusID);

        }
    }
}
