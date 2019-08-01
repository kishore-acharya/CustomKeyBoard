using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Database;
using Android.Views;
using Android.Widget;
using CustomKeyBoard.Models;
using Java.Lang;

namespace CustomKeyBoard
{
    public class ListViewAdapter : BaseAdapter<Credentials>
    {
        private ManageCredentials storeCredentialsActivity;
        private List<Credentials> listSource;

        public ListViewAdapter(ManageCredentials storeCredentialsActivity, List<Credentials> listSource)//gets list source from db
        {
            this.storeCredentialsActivity = storeCredentialsActivity;
            this.listSource = listSource;
        }

        public override Credentials this[int position]
        {
            get
            {
                return listSource[position];
            }
        }

        public override int Count
        {

            get { return listSource.Count; }

        }
        public override long GetItemId(int position)
        {
            return listSource[position].Id;

        }
       

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

     

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            try
            {
                if (row == null)
                {
                    row = LayoutInflater.From(storeCredentialsActivity).Inflate(Resource.Layout.CredentialListTemplate , null, false);
                }
                TextView txtUserName = row.FindViewById<TextView>(Resource.Id.User_field);
                txtUserName.Text = listSource[position].UserName;
                TextView txtPass = row.FindViewById<TextView>(Resource.Id.Pass_field);
                txtPass.Text = listSource[position].Password;
                TextView txtDomain = row.FindViewById<TextView>(Resource.Id.Domain_field);
                txtDomain.Text = listSource[position].Domain;
            }
            catch (Java.Lang.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally { }
            return row;
        }



    }
}