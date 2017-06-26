using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BadmintonBoard.Player;
using Xamarin.Forms;

namespace BadmintonBoard.Login
{
    public class LoginViewModel
    {
        private readonly LoginPage m_loginPage;

        public LoginViewModel(LoginPage loginPage)
        {
            m_loginPage = loginPage;
        }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    var authenticated = await App.Authenticator.SignInAsync();
                    if (authenticated)
                    {
                        App.UserId = DataManager.DefaultManager.CurrentClient.CurrentUser.UserId.Split(':').LastOrDefault();

                        NavigationPage loginPage = Application.Current.MainPage as NavigationPage;
                        if (loginPage != null)
                            await loginPage.Navigation.PushModalAsync(new MainPage());
                    }

                });
            }
        }

    }
}
