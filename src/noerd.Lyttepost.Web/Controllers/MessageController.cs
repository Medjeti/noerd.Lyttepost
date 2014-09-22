using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using noerd.Lyttepost.Core.Models;
using noerd.Lyttepost.Core.Services;

namespace noerd.Lyttepost.Web.Controllers
{
    public class MessageController : ApiController
    {
        [HttpGet]
        public List<LPEntity> GetMessages()
        {

            var list = TwitterService.GetTweets("fisse");

            //var msg = new LPEntity()
            //{
            //    Id = 0,
            //    Source = "",
            //    Text = "Hello World"
            //};
            return list;
        }
    }
}
