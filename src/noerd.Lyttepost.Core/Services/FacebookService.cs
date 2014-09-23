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
    public static class FacebookService
    {
        // App access token: 709346605812399|MfN6qtm_l5ZuSFO538EHBj-r53A

        // Medjetis access token
        //private static string _accessToken = "CAAKFJaB2Sq8BAAuwR21ebXgYV94wbh8BeOyJN4mmAdQzMfwzmhgI5MCXxFfD5DrJy0fd7oQHrQK0pOkO5Y05f9mM0uMthF2ybyWMZCmXTQJWO1t4ihnJwdUcjuRS7IWPLR4RjeXlvjX6rknmPH6des7s9PMMovZA9NOlz4UFe0vqGCyICk7wKUKTIl3JkKkNqfb0qPAv1C0GLlKLYUDtxQ4awgvVMZD";
        private static string _accessToken = "";
        private const string APP_ID = "709346605812399";
        private const string APP_SECRET = "30d69867085ea2de28d4d74dbc8edf19";

        // ---------------------------------------------------------------------------------


        public static IEnumerable<LPEntity> DoSearch(string query, int maxCount)
        {
            var client = new RestClient("https://graph.facebook.com");
            var request = new RestRequest("search", Method.GET);
            request.AddParameter("q", query);
            request.AddParameter("type", "page");
            request.AddParameter("access_token", AccessToken);

            var response = client.Execute<FacebookSearchResponseWrapper>(request);

            var posts = response.Data.Data;
            var list = posts.Take(maxCount).Select(x => new LPEntity() { Id = x.Id, Text = x.Name, Source = "Facebook" });

            //var list = new List<LPEntity>() { new LPEntity() { Text = response.Content } };
            
            
            
            return list;
        }
        
        // ---------------------------------------------------------------------------------

        private static void Authenticate()
        {
            var client = new RestClient("https://graph.facebook.com");
            var request = new RestRequest("oauth/access_token", Method.GET);
            request.AddParameter("client_id", APP_ID);
            request.AddParameter("client_secret", APP_SECRET);
            request.AddParameter("grant_type", "client_credentials");

            var response = client.Execute(request);

            AccessToken = response.Content.Replace("access_token=", "");
        }

        // ---------------------------------------------------------------------------------
        // ---------------------------------------------------------------------------------

        public static string AccessToken
        {
            get
            {
                if (_accessToken == "")
                    Authenticate();

                return _accessToken;
            }
            set { _accessToken = value; }
        }
    }
}
