using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public class InstagramItem
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public string Filter { get; set; }
            public string[] Tags { get; set; }
        }
    }
}
