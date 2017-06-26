using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonBoard.Venue
{
    public class Venue
    {
        public Venue(string name)
        {
            Name = name;
            Id = Guid.NewGuid().ToString();
        }

        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
