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

        private Credentials currentcredentials;
        private EditText UserField, DomainField, PassField;
        private View SaveButton;
        private View CancelButton;
        private DataBaseService db = new DataBaseService();
        private int modificationId = -1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddCredentials);

            if (Intent.GetBooleanExtra("IsModify", false))
            {
                modificationId = Intent.GetIntExtra("ID", -1);
            }

            SetBindings(modificationId);
            // Create your application here
        }
        private void SetBindings(int modificationId)
        {
            UserField = this.FindViewById<EditText>(Resource.Id.editText1);
            DomainField = this.FindViewById<EditText>(Resource.Id.editText2);
            PassField = this.FindViewById<EditText>(Resource.Id.editText3);
            CancelButton = this.FindViewById<View>(Resource.Id.CancelButton);
            SaveButton = this.FindViewById<View>(Resource.Id.Save_Button);
            CancelButton.Click += CancelButton_Click;

            if (modificationId == -1)//No modification hence adding new entry
            {
                currentcredentials = new Credentials();
                SaveButton.Click += SaveButton_Click;
            }
            else//request for modification
            {
                currentcredentials = db.FetchCredentialsFromID(modificationId);
                UserField.Text = currentcredentials.UserName;
                DomainField.Text = currentcredentials.Domain;
                PassField.Text = currentcredentials.Password;
                SaveButton.Click += SaveButton_Click_Modify;
            }
        }

        private void SaveButton_Click_Modify(object sender, EventArgs e)
        {
            try
            {
                ValidateCurrentCredentials();
                db.UpdateCredentials(currentcredentials);
                SetResult(Result.Ok);
                Finish();
            }
            catch (Exception exp)
            {

                ShowGenericError("Data could not be Modified");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            SetResult(Result.Canceled);
            Finish();
        }

        private void ValidateCurrentCredentials()
        {
            currentcredentials.Domain = DomainField.Text;
            currentcredentials.UserName = UserField.Text;
            currentcredentials.Password = PassField.Text;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateCurrentCredentials();
                db.SaveCredentials(currentcredentials);
                SetResult(Result.Ok);
                Finish();
            }
            catch (Exception exp)
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