﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noerd.Lyttepost.Core.Models
{
    public class LPEntity
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Source { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
