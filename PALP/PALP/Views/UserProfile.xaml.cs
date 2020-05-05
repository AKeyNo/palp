using PALP.Models;
using PALP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PALP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProfile : ContentPage
	{
		UserDatabaseController controller = new UserDatabaseController();
		public UserProfile ()
		{
			InitializeComponent();
			setValues();
		}

		private void setValues()
		{
			User user = controller.returnCurrentUser(IsLoggedIn.ID);
			Users_Name.Text = user.FirstName + " " + user.LastName;
			User_Services.Text = user.Services;
			User_Rating.Text = user.Rating.ToString();
			User_Bio.Text = user.Bio;
			UserTimes.Text = user.Times;
			User_Dates.Text = user.Dates;
			User_Addr.Text = user.Address;
			User_email.Text = user.FirstName + user.LastName + "@palp.com";
			User_Zip.Text = user.ZipCode;
		}

		private async void Update_User(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new UserDownload());
		}
    }
}