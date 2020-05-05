using PALP.Models;
using PALP.Data;
using PALP.Views;
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
    public partial class UserFromList : ContentPage
    {
        UserDatabaseController controller = new UserDatabaseController();
        public UserFromList()
        {
            InitializeComponent();
        }

    

        private void setValues(User u)
        {
            Users_1Name.Text = u.FirstName + " " + u.LastName;
            // Users_2Name.Text= u.LastName;
            User_Services.Text = u.Services;
            User_Rating.Text = u.Rating.ToString();
            User_Bio.Text = u.Bio;
            Users_Dates.Text = u.Dates;
            Users_Times.Text = u.Times;
            User_Zip.Text = u.ZipCode;
            User_email.Text = u.FirstName + u.LastName + "@palp.com";


        }

        
    }
}