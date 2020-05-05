using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SQLitePCL;
using PALP.Models;
using PALP.Data;
using PALP.Views;


namespace PALP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class servicePage : ContentPage
    {
        UserDatabaseController s = new UserDatabaseController();
        public servicePage()
        {

            InitializeComponent();
            listOfUsers.ItemsSource = userlist.users;
        }

        private void OnDelete(object sender, System.EventArgs e)
        {
            var listItem = ((MenuItem)sender);
            var usr = (User)listItem.CommandParameter;

            userlist.users.Remove(usr);
        }
        private void onAdd(object sender, System.EventArgs e)
        {
            int c = IsLoggedIn.ID;
            User rigo = s.returnCurrentUser(c);
            userlist.users.Add(rigo);
        }

        async void onView(object sender, EventArgs args)
        {
            var listItem = ((MenuItem)sender);
            var secondPage = new UserFromList();
            var usr = (User)listItem.CommandParameter;
            secondPage.BindingContext = usr;
            await Navigation.PushAsync(secondPage);

        }
    }


  
}
