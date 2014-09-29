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

            var client = new RestClient("https://api.instagram.com");
            var request = new RestRequest(string.Format("v1/tags/{0}/media/recent", query), Method.GET);
            request.AddParameter("count", maxCount);
            request.AddParameter("client_id", CLIENT_ID);
            //request.AddParameter("access_token", AccessToken);

            var response = client.Execute<InstagramSearchResponse.InstagramSearchResponseWrapper>(request);
            
            //var list = new List<LPEntity>() { new LPEntity() { Text = response.Content } };

            var posts = response.Data.Data;
            var list = posts.Take(maxCount).Select(x => new LPEntity()
            {
                Id = x.Id, 
                Text = x.Caption.Text,
                Type = x.Type,
                URL = x.Link,
                //CreatedAt = DateTime.FromFileTime(x.Caption.CreatedTime),
                Source = "Instagram" ,
                Tags = x.Tags,
                Media = new LPMedia() { Thumbnail = x.Images.Thumbnail.Url, URL = x.Images.Image != null ? x.Images.Image.Url : "" }
            });

            return list;
        }

        // ---------------------------------------------------------------------------------

        private static void Authenticate()
        {

        }
    }
}
