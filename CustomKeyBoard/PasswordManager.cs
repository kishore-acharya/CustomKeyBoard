using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.AccessibilityServices;
using Android.App;
using Android.App.Assist;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Service.Autofill;
using Android.Views;
using Android.Views.Accessibility;
using Android.Widget;

namespace CustomKeyBoard
{
    class PasswordManager : AccessibilityService
    {
        public PasswordManager(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            
        }

        public void onFillRequest(FillRequest request, CancellationSignal cancellationSignal,
       FillCallback callback)
        {

           
        }
        public override void OnAccessibilityEvent(AccessibilityEvent e)
        {
            throw new NotImplementedException();
        }

        public override void OnInterrupt()
        {
            throw new NotImplementedException();
        }
    }
}