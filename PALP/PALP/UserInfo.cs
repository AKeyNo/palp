using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PALP
{
    class UserInfo
    {
        public int id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public double Rating
        {
            get;
            set;
        }
        public string Bio
        {
            get;
            set;
        }
        public string Services
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public UserInfo(string n, string b, string ser, double rat, string em)
        {
            n = Name;
            b = Bio;
            ser = Services;
            rat = Rating;
            em = Email;

        }
        public UserInfo()
        {

        }
        void ListViewDemoPage()
        {
            Label header = new Label
            {
                Text = "ListView",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            // Define some data.
            List<UserInfo> users = new List<UserInfo>
            {
               
                new UserInfo("Yvonne", "loves pets","walking,sitting",6.0,"vega@gmail.com")
            };

            // Create the ListView.
            ListView listView = new ListView
            {
                // Source of data items.
                ItemsSource = users,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");

                    Label birthdayLabel = new Label();
                    birthdayLabel.SetBinding(Label.TextProperty,
                        new Binding("bio", BindingMode.OneWay,
                            null, null, "services"));

                    BoxView boxView = new BoxView();
                    boxView.SetBinding(BoxView.ColorProperty, "FavoriteColor");

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                                    {
                                    boxView,
                                    new StackLayout
                                    {
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            nameLabel,
                                            birthdayLabel
                                        }
                                        }
                                    }
                        }
                    };
                })
            };

          
        }
    }
}