using PALP.Data;
using PALP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PALP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        UserDatabaseController userData = new UserDatabaseController();
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            ActivitySpinner.IsVisible = false;
            LoginLogo.HeightRequest = Constants.LoginLogoHeight;

            Ent_Username.Completed += (s, e) => Ent_Password.Focus();
            Ent_Password.Completed += (s, e) => SignInClicked(s, e);
            App.StartCheckIfInternet(Lbl_NoInternet, this);
        }

        async void signup_ClickedEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
        
        async void SignInClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Ent_Username.Text) && !string.IsNullOrWhiteSpace(Ent_Password.Text))
            {
               
                var validate = userData.LoginValidate(Ent_Username.Text, Ent_Password.Text);
                if (validate)
                {
                    ActivitySpinner.IsVisible = true;
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Login Failed", "Username or Password Invalid", "OK");
                }
                
               
               
            }
            else
            {
                await DisplayAlert("Login", "Login Error, Empty Username or Password", "Ok");
            }
        }
    }
}