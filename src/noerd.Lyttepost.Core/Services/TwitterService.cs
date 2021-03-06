﻿using System;
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
        private const bool REQUIRE_MEDIA = false;

        // ---------------------------------------------------------------------------------


        public static IEnumerable<LPEntity> DoSearch(string query, int maxCount)
        {
            Authenticate();

            var searchParameter = Search.GenerateSearchTweetParameter(query);
            searchParameter.MaximumNumberOfResults = maxCount;
            var tweets = Search.SearchTweets(searchParameter).Where(x => (REQUIRE_MEDIA ? x.Media != null : true));
            
            //var media = tweets.Where(x => x.Media.Any());

            var list = tweets.Take(maxCount).Select(tweet => new LPEntity()
            {
                Id = tweet.Id.ToString(),
                Text = tweet.Text,
                Source = "Twitter",
                Type = tweet.Source,
                CreatorName = tweet.Creator.Name,
                CreatorNick = tweet.Creator.ScreenName,
                CreatorImage = tweet.Creator.ProfileImageUrl.Replace("_normal", ""),
                //Creator = "@" + tweet.Creator.ScreenName,
                CreatedAt = tweet.CreatedAt,
                Tags = tweet.Hashtags.Select(tag => tag.Text),
                Place = tweet.Place != null ? tweet.Place.FullName : "",
                Media = tweet.Media != null && tweet.Media.Any() ?
                    tweet.Media.Select(x => new LPMedia()
                    {
                        Id = x.Id.ToString(),
                        Thumbnail = x.MediaURL,
                        URL = "http://" + x.DisplayURL
                    })
                 : null
            });

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
