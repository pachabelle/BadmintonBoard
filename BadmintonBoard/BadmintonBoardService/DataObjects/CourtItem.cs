using Microsoft.Azure.Mobile.Server;

namespace BadmintonBoardService.DataObjects
{
    public class CourtItem : EntityData
    {
        public string Name { get; set; }
        public string VenueId { get; set; }
        public int NumberOfPlayers { get; set; }
    }
}