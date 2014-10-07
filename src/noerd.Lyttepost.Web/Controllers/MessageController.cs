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
        public IEnumerable<LPEntity> GetMessages([FromUri] string q)
        {
            bool searchTwitter = true;
            bool searchInstagram = true;
            var list = SearchService.Search(q, searchTwitter, searchInstagram);

            return list;
        }
    }
}
