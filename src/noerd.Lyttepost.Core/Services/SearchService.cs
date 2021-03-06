﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noerd.Lyttepost.Core.Models;

namespace noerd.Lyttepost.Core.Services
{
    public static class SearchService
    {
        private const int MAX_COUNT = 20;

        public static IEnumerable<LPEntity> Search(string query, bool searchTwitter, bool searchInstagram)
        {            
            var list = new List<LPEntity>();

            if (searchTwitter)
                list.AddRange(TwitterService.DoSearch(query, MAX_COUNT));

            //list.AddRange(FacebookService.DoSearch(query, MAX_COUNT));

            if (searchInstagram)
                list.AddRange(InstagramService.DoSearch(query, MAX_COUNT));

            var rnd = new Random(); 
            list = list.OrderBy(x => rnd.Next()).ToList();

            return list;
        }
    }
}
