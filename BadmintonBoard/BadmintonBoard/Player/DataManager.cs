using System.Collections.Generic;
using System.Threading.Tasks;
using BadmintonBoard.Venue;
using Microsoft.WindowsAzure.MobileServices;

namespace BadmintonBoard.Player
{
    public partial class DataManager
    {
        private readonly IMobileServiceTable<Player> m_playerTable;
        private readonly IMobileServiceTable<Court> m_courtTable;
        private readonly IMobileServiceTable<Venue.Venue> m_venueTable;

        private DataManager()
        {
            CurrentClient = new MobileServiceClient(MobileServiceConstants.AppUrl);
            m_playerTable = CurrentClient.GetTable<Player>();
            m_courtTable = CurrentClient.GetTable<Court>();
            m_venueTable = CurrentClient.GetTable<Venue.Venue>();
        }

        public static DataManager DefaultManager { get; private set; } = new DataManager();

        public MobileServiceClient CurrentClient { get; }

        public async Task AddPlayerAsync(Player item)
        {
            try
            {
                await m_playerTable.InsertAsync(item);
            }
            catch { }
        }

        public async Task<List<Player>> GetAllPlayersAync()
        {
            var activity = new List<Player>();

            try
            {
                var items = await m_playerTable.ToEnumerableAsync();
                activity.AddRange(items);
            }
            catch { }

            return activity;
        }

        public async Task AddCourtAsync(Court item)
        {
            try
            {
                await m_courtTable.InsertAsync(item);
            }
            catch { }
        }

        public async Task<List<Court>> GetAllCourtsAync()
        {
            var courts = new List<Court>();

            try
            {
                var items = await m_courtTable.ToEnumerableAsync();
                courts.AddRange(items);
            }
            catch { }

            return courts;
        }

        public async Task AddVenueAsync(Venue.Venue item)
        {
            try
            {
                await m_venueTable.InsertAsync(item);
            }
            catch { }
        }

        public async Task<List<Venue.Venue>> GetAllVenuesAync()
        {
            var venues = new List<Venue.Venue>();

            try
            {
                var items = await m_venueTable.ToEnumerableAsync();
                venues.AddRange(items);
            }
            catch { }

            return venues;
        }
    }

    public static class DataManagerHelper
    {
        public static async void AddPlayerAsync(Player player)
        {
            try
            {
                await DataManager.DefaultManager.AddPlayerAsync(player);
            }
            catch { }
        }

        public static async void AddVenueAsync(Venue.Venue venue)
        {
            try
            {
                await DataManager.DefaultManager.AddVenueAsync(venue);
            }
            catch { }
        }

        public static async void AddCourtAsync(Court court)
        {
            try
            {
                await DataManager.DefaultManager.AddCourtAsync(court);
            }
            catch { }
        }
    }
}
