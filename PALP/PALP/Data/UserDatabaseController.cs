using PALP.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PALP.Data
{
    public class UserDatabaseController
    {
        private SQLiteConnection _SQLiteConnection;

        public UserDatabaseController()
        {
            _SQLiteConnection = DependencyService.Get<ISQLite>().GetConnection();
            _SQLiteConnection.CreateTable<User>();
        }
        public IEnumerable<User> GetUsers()
        {
            return (from u in _SQLiteConnection.Table<User>()
                    select u).ToList();
        }

        public User GetSpecificUser(int id)
        {
            return _SQLiteConnection.Table<User>().FirstOrDefault(t => t.Id == id);
        }

        public string SaveUser(User user)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = data.Where(x =>x.Username == user.Username).FirstOrDefault();
            if (d1 == null)
            {
                _SQLiteConnection.Insert(user);
                return "Sucessfully Added";
            }
            else
                return "Already Mail id Exist";
        }

        public void DeleteUser(int id)
        {
            _SQLiteConnection.Delete<User>(id);
        }

        public bool LoginValidate(string userName1, string pwd1)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = data.Where(x => x.Username == userName1 && x.Password == pwd1).FirstOrDefault();
            if (d1 != null)
            {
                RestService rest = new RestService();
                rest.Login(d1);
                IsLoggedIn loggedIn = new IsLoggedIn();
                loggedIn.setID(d1.Id);
                return true;
            }
            else
                return false;          
        }
        public bool updateUserValidation(string userid)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = (from values in data
                      where values.Username == userid
                      select values).Single();
            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool updateUser(int userid,string fname, string lname, double rate, string serve, string bio,string dates, string times, string add,string zip)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = (from values in data
                      where values.Id == userid select values).Single();
           
            if (d1 != null)
            {
                d1.FirstName = fname;
                d1.LastName = lname;
                d1.Rating = rate;
                d1.Services = serve;
                d1.Bio = bio;
                d1.Dates = dates;
                d1.Times = times;
                d1.Address = add;
                d1.ZipCode = zip;
                _SQLiteConnection.Update(d1);
                return true;
            }
            else
                return false;
        }

        public User returnCurrentUser(int userid)
        {
            var data = _SQLiteConnection.Table<User>();
            var d1 = data.Where(x => x.Id == userid).FirstOrDefault();
           
            return d1;
           

        }

    }
}
