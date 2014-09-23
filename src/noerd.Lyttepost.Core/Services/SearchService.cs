using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noerd.Lyttepost.Core.Models;

namespace noerd.Lyttepost.Core.Services
{
    public static class SearchService
    {
        public static List<LPEntity> Search(string query)
        {
            var list = new List<LPEntity>();

            //list.AddRange(TwitterService.DoSearch(query));
            list.AddRange(FacebookService.DoSearch(query));

            return list;
        }
    }
}
