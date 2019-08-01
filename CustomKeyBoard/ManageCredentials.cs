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
using Android.Support.V4.App;
using Android.Content.PM;
using static Android.Widget.AdapterView;

namespace CustomKeyBoard
{
    [Activity(Label = "ManageCredentials", MainLauncher = true)]

    public class ManageCredentials :Activity
    {
        
        Credentials MockCredentials = new Credentials();       
        ListView listView;
        ImageView addbutton;
        long currentitemid;
       
        List<Credentials> listSource = new List<Credentials>();
        DataBaseService db=new DataBaseService();
        private const int _RequestCode_Add_Credentials = 23;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.StoreCredentialsLayout);
            listView = FindViewById<ListView>(Resource.Id.listView);
            RegisterForContextMenu(listView);
            listView.ItemClick += ListView_ItemClick;
            addbutton = FindViewById<ImageView>(Resource.Id.AddButton);
            addbutton.Click += Addbutton_Click;
            LoadData();

        }



		public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
		{
			menu.Add(Resource.String.Delte_Menue);
		}
        public override bool OnContextItemSelected(IMenuItem item)//experimental
        {
            long ID;
            AdapterContextMenuInfo info = (AdapterContextMenuInfo)item.MenuInfo;
            ID = listView.GetItemIdAtPosition(info.Position);
            if (item.TitleCondensedFormatted.ToString() == "Delete")
            {

                db.DeleteCredentials((int)ID);
                LoadData();
                return true;
            }
            return false;
        }
        

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Todo Autofill credentials
           
        }

        private void Addbutton_Click(object sender, EventArgs e)//database entry button clicked
        {
            //Database entry fragement
            LaunchAddCredentialsActivity();
            
                      
        }

        private void LoadData()
        {
          
            listSource = db.FetchAllCredentials();//db sends mock data for now         
            IListAdapter adapter = new ListViewAdapter(this, listSource);
            listView.Adapter = adapter;
                  
        }
        public void ShowGenericError(string title = "This feature is under construction")
        {
            Toast.MakeText(this, title, Android.Widget.ToastLength.Long).Show();
        }

        public void LaunchAddCredentialsActivity()
        {
            Intent intent = new Intent(this, typeof(AddCredentials));
            StartActivityForResult(intent, _RequestCode_Add_Credentials);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if(requestCode == _RequestCode_Add_Credentials && resultCode == Result.Ok)
            {
                LoadData();
            }
            
        }

    }
}