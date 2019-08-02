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
        private readonly Context context;
        private List<Credentials> listSource;

        public ListViewAdapter(Context context, List<Credentials> listSource)//gets list source from db
        {
            this.context = context;
            this.listSource = listSource;
        }

        public void ResetData(List<Credentials> listSource)
        {
            this.listSource = listSource;
            NotifyDataSetChanged();
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
            ViewHolder viewHolder = null;
            
            try
            {
                if (convertView == null)
                {
                    convertView = LayoutInflater.From(context).Inflate(Resource.Layout.CredentialListTemplate , null, false);
                    viewHolder = new ViewHolder
                    {
                        txtUserName = convertView.FindViewById<TextView>(Resource.Id.User_field),
                        txtPass = convertView.FindViewById<TextView>(Resource.Id.Pass_field),
                        txtDomain = convertView.FindViewById<TextView>(Resource.Id.Domain_field)
                    };
                    convertView.Tag = viewHolder;
                }
                else
                {
                    viewHolder = convertView.Tag as ViewHolder;
                }


                viewHolder.txtUserName.Text = listSource[position].UserName;
                viewHolder.txtPass.Text = listSource[position].Password;
                viewHolder.txtDomain.Text = listSource[position].Domain;
            }
            catch (Java.Lang.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return convertView;
        }

        private class ViewHolder : Java.Lang.Object
        {
            public TextView txtUserName;
            public TextView txtPass;
            public TextView txtDomain;
        }
    }
}