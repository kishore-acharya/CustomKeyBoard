using Android.AccessibilityServices;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.InputMethodServices;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Views.InputMethods;
using Android.Views.TextService;
using Android.Widget;
using Java.Lang;
using System;
using System.Collections.Generic;

namespace CustomKeyBoard
{
    //[Service(Permission = "android.permission.BIND_INPUT_METHOD", Label = "Kishore Keyboard")]
    //[MetaData("android.view.im", Resource = "@xml/method")]
    //[IntentFilter(new string[] { "android.view.InputMethod" })]
    public class MainActivity : InputMethodService, KeyboardView.IOnKeyboardActionListener
    {

        private KishoreKeyboardView kv;
        private IInputConnection ic;
        private Keyboard keyboard;
        private Keyboard CapsKeyboard;
      
        private bool CapsFlag = false;
        private string selectedText;
        private Vibrator vibrator;
        private IList<int> _PreviewDisabledKeys;
        private ImageView PassButton;
        private TextView Suggestion1, Suggestion2, Suggestion3;
        private const int Vibration_MS = 10;
        private const int Vibation_Amp = 30;


        public override void OnCreate()
        {

            PopulatePreviewDisabledList();
            vibrator = (Vibrator)GetSystemService(VibratorService);
            Console.WriteLine("OnCreate call , Debug starts here");//debug         
            base.OnCreate();
        }

        public void LaunchCredentialActivity()
        {
           Intent intent = new Intent(this, typeof(ManageCredentials));          
           StartActivity(intent);
        }

        public override View OnCreateInputView()
        {
            Console.WriteLine("OnCreateInputView Start");
            View parent = LayoutInflater.Inflate(Resource.Layout.strip, null);
            kv = (KishoreKeyboardView)parent.FindViewById<KishoreKeyboardView>(Resource.Id.Keyboard);
            //kv = (KishoreKeyboardView)LayoutInflater.Inflate(Resource.Layout.keyboard, null);
            keyboard = new Keyboard(this, Resource.Xml.qwerty);
            kv.Keyboard = keyboard;
            kv.OnKeyboardActionListener = this;

            Window w = this.Window.Window;
            w.SetNavigationBarColor(new Color(ContextCompat.GetColor(this, Resource.Color.keyboard_background_color))); //to change bottom navigation bar color   


            PassButton = (ImageView)parent.FindViewById<ImageView>(Resource.Id.pass_button_view);//autofill buton
            PassButton.Click += PassButton_Click;

            Suggestion1 = (TextView)parent.FindViewById<TextView>(Resource.Id.suggestion1);
            Suggestion2 = (TextView)parent.FindViewById<TextView>(Resource.Id.suggestion2);
            Suggestion3 = (TextView)parent.FindViewById<TextView>(Resource.Id.suggestion3);
            Suggestion1.Click += Suggestion1_Click;
            Suggestion2.Click += Suggestion2_Click;
            Suggestion3.Click += Suggestion3_Click;


            Console.WriteLine("Onclick event created");

            return parent;
            // return kv;

        }
        
        public override View OnCreateCandidatesView()//THE UPPER STRIP
        {

            Suggestion1 = Suggestion2 = Suggestion3 = null;
            return base.OnCreateCandidatesView();
          
        }

        public void ShowGenericError(string title = "This feature is under construction")
        {
            Toast.MakeText(this, title, Android.Widget.ToastLength.Long).Show();
        }

        private void Suggestion3_Click(object sender, EventArgs e)
        {
            ShowGenericError();

        }

        private void Suggestion2_Click(object sender, EventArgs e)
        {
            ShowGenericError();

        }

        private void Suggestion1_Click(object sender, EventArgs e)
        {
            
            ShowGenericError();

        }

        private void PassButton_Click(object sender, EventArgs e)
        {

            Console.WriteLine("Onclick event exectured");
            LaunchCredentialActivity();            
           // ShowGenericError();
            //throw new NotImplementedException();
        }

        private void PopulatePreviewDisabledList()
        {
            if (null != _PreviewDisabledKeys) return;
            _PreviewDisabledKeys = new List<int> { this.Resources.GetInteger(Resource.Integer.code_space), this.Resources.GetInteger(Resource.Integer.code_done),
                                                    this.Resources.GetInteger(Resource.Integer.code_del), this.Resources.GetInteger(Resource.Integer.code_caps),
             this.Resources.GetInteger(Resource.Integer.code_symbols)};
        }

        public void OnKey([GeneratedEnum] Android.Views.Keycode primaryCode, [GeneratedEnum] Android.Views.Keycode[] keyCodes)
        {

            Console.WriteLine("On key invoked , value is " + primaryCode);
            ic = CurrentInputConnection;//to get current input connection


            if (ic == null)
            {
                return;
            }

            switch (primaryCode)
            {
                case (Android.Views.Keycode.Del):
                    selectedText = ic.GetSelectedText(0);
                    if (string.IsNullOrEmpty(selectedText))
                    {
                        ic.DeleteSurroundingText(1, 0);
                    }
                    else
                    {
                        ic.CommitText("", 1);
                       
                    }
                    break;
                case (Android.Views.Keycode.CapsLock)://To toggle caps lock


                    if (!CapsFlag)//caps lock was off
                    {
                        CapsKeyboard = new Keyboard(this, Resource.Xml.caps_qwerty);
                        kv.Keyboard = CapsKeyboard;
                        kv.OnKeyboardActionListener = this;
                        CapsFlag = true;
                    }
                    else//caps lock was already onon
                    {
                        kv.Keyboard = keyboard;
                        kv.OnKeyboardActionListener = this;
                        CapsFlag = false;
                    }
                    break;
                case (Android.Views.Keycode.S)://this is because ASCII value 115 for s is same as android enum for caps lock
                    {
                        ic.CommitText("s", 1);

                        break;
                    }
                case (Android.Views.Keycode.C)://this is because ASCII value 115 for C (caps) is same as android enum for backspace
                    {
                        ic.CommitText("C", 1);

                        break;
                    }


                default:
                    char code = (char)(primaryCode);



                    ic.CommitText(code.ToString(), 1);// to provides the keystroke to input area according to ascai value of code


                    break;
            }
            Console.WriteLine("On key call end");//debug
            Console.WriteLine("Preview enabled value is: " + kv.PreviewEnabled);


        }

        public override bool OnKeyDown([GeneratedEnum] Android.Views.Keycode keyCode, KeyEvent e)
        {
            ShowGenericError("OnKeydown is activated");
            return base.OnKeyDown(keyCode, e);
        }


        // to vibrate on key press
        private void VibrateOnKey(int ms)
        {
            if (ms > 0)
            {
                if (Build.VERSION.SdkInt >= (BuildVersionCodes)26)
                {
                    vibrator.Vibrate(VibrationEffect.CreateOneShot(ms, Vibation_Amp));
                    //public static VibrationEffect createPredefined(EFFECT_CLICK); for android but can't find here
                }
                else
                {
                    vibrator.Vibrate(ms);

                }
            }
            Console.WriteLine("vibrate on key  call end");//debug
            Console.WriteLine("Preview enabled value is: " + kv.PreviewEnabled);

        }

        public void SwipeLeft()
        {
        }

        public void SwipeRight() { }

        public void SwipeDown()
        {
            kv.Keyboard = keyboard;
            kv.OnKeyboardActionListener = this;
            CapsFlag = false;
        }

        public void SwipeUp()
        {
            CapsKeyboard = new Keyboard(this, Resource.Xml.caps_qwerty);
            kv.Keyboard = CapsKeyboard;
            kv.OnKeyboardActionListener = this;
            CapsFlag = true;
        }

        private int compcode;
        private Android.Views.Keycode lastCode = Android.Views.Keycode.Unknown;
        private bool wasreleased = true;

        public void OnPress([GeneratedEnum] Android.Views.Keycode primaryCode)
        {
            //Handle Vibrations         
            if (wasreleased)
            {
                VibrateOnKey(Vibration_MS);
                wasreleased = false;
            }
            else
            {
                VibrateOnKey(0);
            }
            Console.WriteLine("OnPress invoked, value is " + primaryCode);

            //handle preview
            if (_PreviewDisabledKeys.Contains((int)primaryCode))
            {
                kv.PreviewEnabled = false;
            }
            else
            {
                kv.PreviewEnabled = true;
            }

        }

        public void OnRelease([GeneratedEnum] Android.Views.Keycode primaryCode)
        {
            kv.PreviewEnabled = false;
            Console.WriteLine("On Release Invoke, value is " + primaryCode);
            wasreleased = true;
        }

        public void OnText(ICharSequence text)
        {
            //throw new System.NotImplementedException();
        }


    }
}