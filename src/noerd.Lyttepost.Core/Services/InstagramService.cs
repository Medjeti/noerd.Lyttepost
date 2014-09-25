using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Tweetinvi;
using noerd.Lyttepost.Core.Models;

namespace noerd.Lyttepost.Core.Services
{
    public static class InstagramService
    {

        private const string CLIENT_ID = "5cb32a5d79b24e10b80995c29a95877c";
        private const string CLIENT_SECRET = "5574c3e64e5240ee92768d1ab21e5a8f";

        // ---------------------------------------------------------------------------------


        public static IEnumerable<LPEntity> DoSearch(string query, int maxCount)
        {

            //

            var client = new RestClient("https://api.instagram.com/");
            var request = new RestRequest("v1/tags/search", Method.GET);
            request.AddParameter("q", query);
            request.AddParameter("client_id", CLIENT_ID);
            //request.AddParameter("access_token", AccessToken);

            var response = client.Execute<InstagramSearchResponse.InstagramSearchResponseWrapper>(request);

            var posts = response.Data.Data;
            //var list = new List<LPEntity>() { new LPEntity() { Text = response.Content } };
            var list = posts.Take(maxCount).Select(x => new LPEntity() { Id = x.MediaCount, Text = x.Name, Source = "Instagram" });

            return list;
        }

        // ---------------------------------------------------------------------------------

        private static void Authenticate()
        {

        }
    }
}
