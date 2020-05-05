using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PALP.Views;
namespace PALP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class petwalking : ContentPage
    {
        public petwalking()
        {
            InitializeComponent();
        }
        async void ShowServiceProviders(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new servicePage());
        }
    }
}