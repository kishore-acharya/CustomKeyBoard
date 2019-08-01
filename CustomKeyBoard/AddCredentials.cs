using System;
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
    [Activity(Label = "AddCredentials")]
    public class AddCredentials : Activity
    {

        Credentials currentcredentials = new Credentials();
        EditText UserField,DomainField,PassField;
        View SaveButton;
        View CancelButton;
        DataBaseService db = new DataBaseService();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddCredentials);
            UserField = this.FindViewById<EditText>(Resource.Id.editText1);
            DomainField = this.FindViewById<EditText>(Resource.Id.editText2);
            PassField = this.FindViewById<EditText>(Resource.Id.editText3);
            SaveButton = this.FindViewById<View>(Resource.Id.Save_Button);
            CancelButton = this.FindViewById<View>(Resource.Id.CancelButton);
            SaveButton.Click += SaveButton_Click;
            CancelButton.Click += CancelButton_Click;

            // Create your application here
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            SetResult(Result.Canceled);
            Finish();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                currentcredentials.Domain = DomainField.Text;
                currentcredentials.UserName = UserField.Text;
                currentcredentials.Password = PassField.Text;
                db.SaveCredentials(currentcredentials);
                SetResult(Result.Ok);
                Finish();
            }
            catch(Exception exp)
            {

                ShowGenericError("Data could not be saved");
            }
        }
        public void ShowGenericError(string title = "This feature is under construction")
        {
            Toast.MakeText(this, title, Android.Widget.ToastLength.Long).Show();
        }
    }
}