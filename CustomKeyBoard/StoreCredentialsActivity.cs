using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CustomKeyBoard.Models;
using CustomKeyBoard.Services;

namespace CustomKeyBoard
{
    [Activity(Label = "StoreCredentialsActivity")]
    public class StoreCredentialsActivity : Activity
    {

        Credentials MockCredentials = new Credentials();       
        ListView listView;
       
        List<Credentials> listSource = new List<Credentials>();
        DataBaseService db=new DataBaseService();
        protected override void OnCreate(Bundle savedInstanceState)
        {
             base.OnCreate(savedInstanceState);
             SetContentView(Resource.Layout.StoreCredentialsLayout);
             listView = FindViewById<ListView>(Resource.Id.listView);//attaching to my listview in layout           
             LoadData();
          
            
           
        }
        private void LoadData()
        {
          
            listSource = db.FetchAllCredentials();//db sends mock data for now
          //  Console.WriteLine("result from  fetch db"+ listSource[0].UserName.ToString());
            IListAdapter adapter = new ListViewAdapter(this, listSource);
            Console.WriteLine("Crash after this line");
            listView.Adapter = adapter;
            //crashing in this line
            
        }
        public void ShowGenericError(string title = "This feature is under construction")
        {
            Toast.MakeText(this, title, Android.Widget.ToastLength.Long).Show();
        }
    }
}