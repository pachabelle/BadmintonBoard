using System;

namespace BadmintonBoard.Venue
{  
    public class Court
    {
        public Court(string name, int numPlayers)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            NumberOfPlayers = numPlayers;
        }

        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        public string VenueId { get; set; }
        public string Name { get; set; }
        public int NumberOfPlayers { get; set; }
    }
}
