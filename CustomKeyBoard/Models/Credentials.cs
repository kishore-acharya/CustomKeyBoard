using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CustomKeyBoard.Models
{
  
    public class Credentials
    {
        private string _userName;
        private string _password;
        private string _domain;
        private int id;

        [PrimaryKey, AutoIncrement]
        public int Id { get => id; set => id = value; }
        public string Domain { get => _domain; set => _domain = value; }
        public string Password { get => _password; set => _password = value; }
        public string UserName { get => _userName; set => _userName = value; }

      
    }
}