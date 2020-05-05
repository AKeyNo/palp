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
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        async void petwalking(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new petwalking());
        }
        async void petsitting(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new petsitting());
        }
        async void petgrooming(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new petgrooming());
        }
        async void petadoption(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new petadoption());
        }
    }
}