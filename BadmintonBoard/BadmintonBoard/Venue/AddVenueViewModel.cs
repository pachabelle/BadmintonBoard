using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BadmintonBoard.Player;
using Xamarin.Forms;

namespace BadmintonBoard.Venue
{
    public class AddVenueViewModel : ObservableBase
    {
        private readonly AddVenuePage m_addVenuePage;
        private readonly ObservableCollection<Court> m_courts = new ObservableCollection<Court>();
        private string m_name;

        public AddVenueViewModel(AddVenuePage addVenuePage)
        {
            m_addVenuePage = addVenuePage;
        }

        public string Name
        {
            get => m_name;
            set => SetProperty(ref m_name, value);
        }

        public IList<Court> Courts => m_courts;
        
        public ICommand AddCourtCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    var addCourtPage = new AddCourt();
                    var addCourtViewModel = new AddCourtViewModel(addCourtPage);

                    addCourtPage.SetBindingContext(addCourtViewModel);
                    addCourtViewModel.CourtAdded += OnCourtAdded;
                    addCourtViewModel.AddCourtCancelled += OnAddCourtCancelled;

                    NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
                    if (mainPage != null)
                    {
                        await mainPage.Navigation.PushModalAsync(addCourtPage);
                    }
                });
            }
        }

        public ICommand CancelCommand => new RelayCommand(async() => await PopPage());

        public ICommand SaveCommand => new RelayCommand(async() => await SaveVenue());

        private void OnAddCourtCancelled(object sender, EventArgs e)
        {
            var addCourtViewModel = sender as AddCourtViewModel;
            if (addCourtViewModel == null)
                return;

            addCourtViewModel.CourtAdded -= OnCourtAdded;
            addCourtViewModel.AddCourtCancelled -= OnAddCourtCancelled;
        }

        private void OnCourtAdded(object sender, CourtEventArgs e)
        {
            var addCourtViewModel = sender as AddCourtViewModel;
            if(addCourtViewModel == null)
                return;

            addCourtViewModel.CourtAdded -= OnCourtAdded;
            addCourtViewModel.AddCourtCancelled -= OnAddCourtCancelled;
            m_courts.Add(e.Court);
        }

        private static async Task PopPage()
        {
            NavigationPage mainPage = Application.Current.MainPage as NavigationPage;
            if (mainPage != null)
                await mainPage.Navigation.PopModalAsync();
        }

        private async Task SaveVenue()
        {
            var venue = new Venue(Name);
            DataManagerHelper.AddVenueAsync(venue);

            var courtsToAdd = m_courts.ToList();
            foreach (var court in courtsToAdd)
            {
                court.VenueId = venue.Id;
                DataManagerHelper.AddCourtAsync(court);
            }

            await PopPage();
        }
    }
}
