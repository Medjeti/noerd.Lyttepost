using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace noerd.Lyttepost.Core.Models
{
    public class InstagramSearchResponse
    {
        public class InstagramSearchResponseWrapper
        {
            public List<InstagramItem> Data { get; set; }
            //public string Id { get; set; }
            //public string Name { get; set; }
        }

        // ---------------------------------------------------------------------------------

        public class InstagramItem
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public string Link { get; set; }
            public InstagramCaption Caption { get; set; }
            //public string Filter { get; set; }
            public List<string> Tags { get; set; }
            public InstagramImages Images { get; set; }
            public InstagramUser User { get; set; }
        }

        // ---------------------------------------------------------------------------------

        public class InstagramCaption
        {
            public string Text { get; set; }
            //public long CreatedTime { get; set; }   
        }

        // ---------------------------------------------------------------------------------

        public class InstagramImages
        {
            public InstagramImage Thumbnail { get; set; }
            [DeserializeAs(Name = "standard_resolution")]
            public InstagramImage Image { get; set; } 
        }

        // ---------------------------------------------------------------------------------

        public class InstagramImage
        {
            public string Url { get; set; } 
        }

        // ---------------------------------------------------------------------------------

        public class InstagramUser
        {
            public string Username { get; set; }
            public string FullName { get; set; }
            public string ProfilePicture { get; set; }
        }

    }
}
