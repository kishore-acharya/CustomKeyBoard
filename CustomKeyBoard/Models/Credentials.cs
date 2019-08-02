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
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Domain { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}