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
        public static List<LPEntity> GetTweets(string query)
        {
            // TODO: Authenticate singleton
            Authenticate();

            var tweets = Search.SearchTweets(query);
            var list = tweets.Select(x => new LPEntity() { 
                Id = x.Id, Text = x.Text, Creator = x.Creator.Name, CreatedAt = x.CreatedAt }).ToList();

            return list;
        }
        
        // -------------------------------------------------------------

        private static void Authenticate() {
            var apiKey = "igSfKvMxd3b7PEyThiA8WN6hM";
            var apiSecret = "0Cfppb0ZCwMG4Ng4wvk8tqjvCEjjt5gQhdyOYi1qPXLrF88gcx";
            var applicationCredentials = CredentialsCreator.GenerateApplicationCredentials(apiKey, apiSecret);
            
            
            //TwitterCredentials.SetCredentials("Access_Token", "Access_Token_Secret", "Consumer_Key", "Consumer_Secret");
            TwitterCredentials.SetCredentials(applicationCredentials.AuthorizationKey, applicationCredentials.AuthorizationSecret, applicationCredentials.ConsumerKey, applicationCredentials.ConsumerSecret);
        }
    }
}
