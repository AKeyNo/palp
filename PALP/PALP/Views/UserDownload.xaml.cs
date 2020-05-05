using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PALP.Data;
using PALP.Models;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PALP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserDownload : ContentPage
	{
		UserDatabaseController controller = new UserDatabaseController();
		public UserDownload ()
		{
			InitializeComponent ();
		}
       async void Save_User(object sender, System.EventArgs e)
        {
			int id = IsLoggedIn.ID;

			if (!string.IsNullOrWhiteSpace(FirstName.Text) &&
				!string.IsNullOrWhiteSpace(LastName.Text) &&
				!string.IsNullOrWhiteSpace(UserRating.Text) &&
				!string.IsNullOrWhiteSpace(UserServices.Text) &&
				!string.IsNullOrWhiteSpace(UserBio.Text) &&
                !string.IsNullOrWhiteSpace(UserDates.Text) &&
                !string.IsNullOrWhiteSpace(UserTimes.Text) &&
                !string.IsNullOrWhiteSpace(UserZipCode.Text) &&
                !string.IsNullOrWhiteSpace(UserAddress.Text))
			{
				
				var change = controller.updateUser(id, FirstName.Text, LastName.Text, Convert.ToInt32(UserRating.Text), UserServices.Text, UserBio.Text,UserDates.Text,UserTimes.Text, UserAddress.Text, UserZipCode.Text);
				if (change)
				{
					await DisplayAlert("Updated", "All Values Have Been Updated", "OK");
					await Navigation.PushAsync(new UserProfile());
				}
				else
				{
					await DisplayAlert("Error", "Failed to Update", "OK");
				}
			}
			else
			{
				await DisplayAlert("Error", "Leave No Blank Values", "OK");
			}

        }
        
    }
}