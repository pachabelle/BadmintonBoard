using System.Collections.Generic;
using System.Collections.ObjectModel;
using BadmintonBoard.Player;
using Xamarin.Forms;

namespace BadmintonBoard.Board
{
    public class SelectVenueViewModel : ObservableBase
    {
        private ObservableCollection<Venue.Venue> m_venues = new ObservableCollection<Venue.Venue>();
        private Venue.Venue m_selectedVenue;

        public SelectVenueViewModel(SelectVenuePage selectVenuePage)
        {
            LoadVenues();
        }

        public IList<Venue.Venue> Venues => m_venues;

        public Venue.Venue SelectedVenue
        {
            get { return m_selectedVenue; }
            set
            {
                SetProperty(ref m_selectedVenue, value);
                if (m_selectedVenue != null)
                    ContinueToBoardPage();
            }
        }

        private async void ContinueToBoardPage()
        {
            var boardPage = new Board();
            var boardViewModel = new BoardViewModel(boardPage, SelectedVenue);
            boardPage.SetViewModel(boardViewModel);

            

            NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
            if (mainPage != null)
            {
                await mainPage.Navigation.PopModalAsync();
                await mainPage.Navigation.PushModalAsync(boardPage);
            }
        }

        private async void LoadVenues()
        {
            m_venues.Clear();

            var venues = await DataManager.DefaultManager.GetAllVenuesAync();
            foreach (var venue in venues)
            {
                m_venues.Add(venue);
            }
        }
    }
}
