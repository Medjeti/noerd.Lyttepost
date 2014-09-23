using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using noerd.Lyttepost.Core.Models;

namespace noerd.Lyttepost.Core.Services
{
    public static class TwitterService
    {

        private static bool IsAuthenticated { get; set; }

        // ---------------------------------------------------------------------------------


        public static List<LPEntity> DoSearch(string query)
        {
            Authenticate();

            var searchParameter = Search.GenerateSearchTweetParameter(query);
            searchParameter.MaximumNumberOfResults = 5;
            var tweets = Search.SearchTweets(searchParameter);

            var list = tweets.Select(tweet => new LPEntity() {
                Id = tweet.Id,
                Text = tweet.Text,
                Source = "Twitter",
                //Creator = tweet.Creator.Name + " (@" + tweet.Creator.ScreenName + ")",
                Creator = "@" + tweet.Creator.ScreenName,
                CreatedAt = tweet.CreatedAt,
                Tags = tweet.Hashtags.Select(tag => tag.Text).ToList()
            }).ToList();

            return list;
        }
        
        // ---------------------------------------------------------------------------------

        private static void Authenticate()
        {
            if (IsAuthenticated)
                return;

            var apiKey = "igSfKvMxd3b7PEyThiA8WN6hM";
            var apiSecret = "0Cfppb0ZCwMG4Ng4wvk8tqjvCEjjt5gQhdyOYi1qPXLrF88gcx";
            var applicationCredentials = CredentialsCreator.GenerateApplicationCredentials(apiKey, apiSecret);
            
            //TwitterCredentials.SetCredentials("Access_Token", "Access_Token_Secret", "Consumer_Key", "Consumer_Secret");
            TwitterCredentials.SetCredentials(applicationCredentials.AuthorizationKey, applicationCredentials.AuthorizationSecret, applicationCredentials.ConsumerKey, applicationCredentials.ConsumerSecret);

            IsAuthenticated = true;
        }
    }
}
