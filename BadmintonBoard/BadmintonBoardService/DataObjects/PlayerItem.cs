using Microsoft.Azure.Mobile.Server;

namespace BadmintonBoardService.DataObjects
{
    public class PlayerItem : EntityData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
    }
}