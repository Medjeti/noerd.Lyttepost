using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using noerd.Lyttepost.Core.Models;
using noerd.Lyttepost.Core.Services;
using noerd.Lyttepost.Core.Services.NoerdBot;

namespace noerd.Lyttepost.Web.Controllers
{
    public class NoerdBotController : ApiController
    {
        [HttpGet]
        public string Go()
        {
            var service = new NoerdBotService();
            return service.StartStream();
        }
    }
}