using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BadmintonBoard.Player;
using Xamarin.Forms;

namespace BadmintonBoard.Venue
{
    public class ManageVenuesViewModel : ObservableBase
    {
        private readonly ManageVenuesPage m_manageVenuesPage;

        private readonly ObservableCollection<Venue> m_venues = new ObservableCollection<Venue>();

        public ManageVenuesViewModel(ManageVenuesPage manageVenuesPage)
        {
            m_manageVenuesPage = manageVenuesPage;
            LoadVenues();
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

        public IList<Venue> Venues => m_venues;

        public ICommand AddVenueCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
                    if (mainPage != null)
                    {
                        await mainPage.Navigation.PushModalAsync(new AddVenuePage());
                    }
                });
            }
        }

        public ICommand FinishCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
                    if (mainPage != null)
                        await mainPage.Navigation.PopModalAsync();
                });
            }
        }
    }
}
