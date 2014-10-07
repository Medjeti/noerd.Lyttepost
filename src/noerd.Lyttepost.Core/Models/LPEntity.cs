using System;
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
        public string Type { get; set; }
        public string URL { get; set; }
        public string Source { get; set; }
        public string CreatorName { get; set; }
        public string CreatorNick { get; set; }
        public string CreatorImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Place { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public LPMedia Media { get; set; }
    }
}
