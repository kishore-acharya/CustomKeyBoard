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
using Android.Util;
using Android.Views;
using Android.Views.Accessibility;
using Android.Widget;

namespace CustomKeyBoard
{
    public class CandidateView : View
    {
        public CandidateView(Context context) : base(context)
        {
        }

        public CandidateView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public CandidateView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public CandidateView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected CandidateView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        internal void setService(MainActivity mainActivity)
        {
            throw new NotImplementedException();
        }
    }
}