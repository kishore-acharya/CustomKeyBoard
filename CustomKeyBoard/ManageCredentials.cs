
using Android.App;
using Android.Content;
using Android.OS;

using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CustomKeyBoard.Models;
using CustomKeyBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using static Android.Widget.AdapterView;

namespace CustomKeyBoard
{
    [Activity(Label = "ManageCredentials")]

    public class ManageCredentials : Activity
    {
        ListView listView;
        ImageView addbutton;
        List<Credentials> listSource = new List<Credentials>();
        DataBaseService db = new DataBaseService();
        private ListViewAdapter adapter;
        private const int _RequestCode_Add_Credentials = 23;
        private const int _RequestCode_Modify_Credentials = 24;

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
            menu.Add(Resource.String.Delete_Menue);
            menu.Add(Resource.String.Modify_Menue);
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
            else if (item.TitleCondensedFormatted.ToString() == "Modify")//User has selected Modify then I am passing Modify=true, and Item Id for modification
            {
                LaunchAddCredentialsActivity(true, (int)ID);//sending Modify=true along with item ID to modify
            }
            return false;
        }


        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Todo Autofill credentials

            SaveSelectedPassword(listSource[e.Position].Password);
            Intent serviceIntent = new Intent(this, typeof(KeyboardService)); ////experimental
            StartService(serviceIntent);
            Finish();
        }

        private void SaveSelectedPassword(string password)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(ApplicationContext);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("Passw0rd", password);
            editor.Apply();        // applies changes asynchronously on newer APIs
        }

        private void Addbutton_Click(object sender, EventArgs e)//database entry button clicked
        {

            LaunchAddCredentialsActivity(); //Database entry fragement                  
        }

        private void LaunchAddCredentialsActivity(bool ModifyData = false, int id = -1)
        {
            Intent intent = new Intent(this, typeof(AddCredentials));
            if (!ModifyData)
            {
                intent.PutExtra("IsModify", false);
                StartActivityForResult(intent, _RequestCode_Add_Credentials);
            }
            else//ModifyData == true
            {
                intent.PutExtra("ID", id);
                intent.PutExtra("IsModify", true);
                StartActivityForResult(intent, _RequestCode_Modify_Credentials);
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if ((requestCode == _RequestCode_Add_Credentials || requestCode == _RequestCode_Modify_Credentials) && resultCode == Result.Ok)
            {
                RefreshData();
            }
        }
        private void LoadData()
        {
            listSource = db.FetchAllCredentials();
            adapter = new ListViewAdapter(this, listSource);
            listView.Adapter = adapter;
        }

        private void RefreshData()
        {
            if (null != adapter)
            {
                listSource = db.FetchAllCredentials();
                adapter.ResetData(listSource);
            }
        }

    }
}