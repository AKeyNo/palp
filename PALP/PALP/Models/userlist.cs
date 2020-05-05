using PALP.Models;
using PALP.Views;
using PALP.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace PALP.Models
{
    public static class userlist
    {
        public static IList<User> users { get; set; }

        static userlist()
        {
            users = new ObservableCollection<User>() {
                new User
                {

                    Username ="test",
                    FirstName ="test",
                    LastName  = "test",
                    Dates ="monday/wednesday",
                    Times = "afternoons",

                    Rating =6.7,
                    Bio = "test",
                }
            };
        }
    }
}
