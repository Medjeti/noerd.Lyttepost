using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace noerd.Lyttepost.Core.Models
{
    public class FacebookSearchResponseWrapper
    {
        public List<FacebookItem> Data { get; set; }
        //public string Id { get; set; }
        //public string Name { get; set; }
    }
    
    public class FacebookItem
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
}
