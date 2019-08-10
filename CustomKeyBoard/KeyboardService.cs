using Android.App;
using Android.Content;
using Android.Graphics;
using Android.InputMethodServices;
using Android.OS;
using Android.Preferences;
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
    [Service(Permission = "android.permission.BIND_INPUT_METHOD", Label = "Kishore Keyboard")]
    [MetaData("android.view.im", Resource = "@xml/method")]
    [IntentFilter(new string[] { "android.view.InputMethod" })]
    public class KeyboardService : InputMethodService, KeyboardView.IOnKeyboardActionListener
    {
        private const int Vibation_Amp = 30;
        private const int Vibration_MS = 10;

        private IList<int> _PreviewDisabledKeys;
        private bool CapsFlag = false;
        private Keyboard CapsKeyboard;

        private IInputConnection ic;
        private Keyboard keyboard;
        private KishoreKeyboardView kv;
        private ImageView PassButton;
        private string selectedText;
        private SpellCheckerSession SplSession;
        private TextView Suggestion1, Suggestion2, Suggestion3;
        private Vibrator vibrator;
        private bool wasreleased = true;
        private Keyboard SymbolsKeyboard;

        public bool SymbolsFlag { get; private set; }

        public override void OnCreate()
        {

            PopulatePreviewDisabledList();
            vibrator = (Vibrator)GetSystemService(VibratorService);
            
            Console.WriteLine("OnCreate call , Debug starts here");//
            base.OnCreate();
        }





        public override View OnCreateInputView()
        {
            Console.WriteLine("OnCreateInputView Start");
            View parent = LayoutInflater.Inflate(Resource.Layout.strip, null);
            kv = parent.FindViewById<KishoreKeyboardView>(Resource.Id.Keyboard);
            //kv = (KishoreKeyboardView)LayoutInflater.Inflate(Resource.Layout.keyboard, null);
            keyboard = new Keyboard(this, Resource.Xml.qwerty);
            kv.Keyboard = keyboard;
            kv.OnKeyboardActionListener = this;

            Window w = this.Window.Window;
            w.SetNavigationBarColor(new Color(ContextCompat.GetColor(this, Resource.Color.keyboard_background_color))); //to change bottom navigation bar color   


            PassButton = parent.FindViewById<ImageView>(Resource.Id.pass_button_view);//autofill buton
            PassButton.Click += PassButton_Click;


            ////bindings
            Suggestion1 = parent.FindViewById<TextView>(Resource.Id.suggestion1);
            Suggestion2 = parent.FindViewById<TextView>(Resource.Id.suggestion2);
            Suggestion3 = parent.FindViewById<TextView>(Resource.Id.suggestion3);
            Suggestion1.Click += Suggestion1_Click;
            Suggestion2.Click += Suggestion2_Click;
            Suggestion3.Click += Suggestion3_Click;


            Console.WriteLine("Onclick event created");

            return parent;


        }
        private void PassButton_Click(object sender, EventArgs e)
        {


            LaunchCredentialActivity();


        }


        private void PopulatePreviewDisabledList()
        {
            if (null != _PreviewDisabledKeys) return;
            _PreviewDisabledKeys = new List<int> { this.Resources.GetInteger(Resource.Integer.code_space), this.Resources.GetInteger(Resource.Integer.code_done),
                                                    this.Resources.GetInteger(Resource.Integer.code_del), this.Resources.GetInteger(Resource.Integer.code_caps),
             this.Resources.GetInteger(Resource.Integer.code_symbols)};
        }

        private void Suggestion1_Click(object sender, EventArgs e)
        {

            ShowGenericError();

        }

        private void Suggestion2_Click(object sender, EventArgs e)
        {
            ShowGenericError();

        }

        private void Suggestion3_Click(object sender, EventArgs e)
        {
            ShowGenericError();

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

        public void ComitAutofill()
        {
           
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(ApplicationContext);
            string value = prefs.GetString("Passw0rd", "No_Autofill");
            if (value != "No_Autofill")
            {
                ic = CurrentInputConnection;
                ic.CommitText(value, value.Length);
            }

            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("Passw0rd", "No_Autofill");
            editor.Apply();
        }

        public void LaunchCredentialActivity()
        {
            Intent intent = new Intent(this, typeof(ManageCredentials));
            StartActivity(intent);
        }


        public override void OnBindInput()
        {
            //  ShowGenericError("OnBindInput called");
            base.OnBindInput();
        }




        ///++++Suggestions Implementation++++/////
        public void OnGetSentenceSuggestions(SentenceSuggestionsInfo[] results)
        {
            throw new NotImplementedException();
        }


        public void OnGetSuggestions(SuggestionsInfo[] results)//populates the recieved suggestion from spellchcker seession
        {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < results.Length; i++)
            {
                //Returned suggestions are contained in SugesstionInfo  
                int len = results[0].SuggestionsCount;
                sb.Append('\n');
                for (int j = 0; j < len; j++) sb.Append(results[i].GetSuggestionAt(j) + " , ");
                sb.Append("(" + len + ")");
            }

            Suggestion1.Text = (sb.ToString());

            ShowGenericError("value of sb is " + sb.ToString());
            //string[] res = sb.Split(',');
            //Suggestion1.Text = res[0];
            //Suggestion2.Text = res[1];
            //Suggestion3.Text = res[2];
        }
        public void OnKey([GeneratedEnum] Android.Views.Keycode primaryCode, [GeneratedEnum] Android.Views.Keycode[] keyCodes)//Main keyboard input method
        {



            ic = CurrentInputConnection;//to get current input connection

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
                        ic.CommitText(string.Empty, 1);

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
                case (Android.Views.Keycode.ButtonA)://this is because ASCII value 115 for s is same as android enum for caps lock
                    {
                        ic.CommitText("/", 1);

                        break;
                    }
                case (Android.Views.Keycode.C)://this is because ASCII value 115 for C (caps) is same as android enum for backspace
                    {
                        ic.CommitText("C", 1);

                        break;
                    }
              
                case (Android.Views.Keycode.Num3)://actually this is done sbutton handling , as i am using Code=10 for my done button, which is code for unused num3
                    {
                        ic.PerformEditorAction(ImeAction.Send);
                        ic.PerformEditorAction(ImeAction.Go);
                        ic.PerformEditorAction(ImeAction.Done);


                        SplSession.Close();//closing spell check session

                        break;
                    }





                default:

                    if((int)primaryCode== 1115)
                    {
                        if (!SymbolsFlag)//symbol view was off
                        {
                            SymbolsKeyboard = new Keyboard(this, Resource.Xml.Symbols);
                            kv.Keyboard = SymbolsKeyboard;
                            kv.OnKeyboardActionListener = this;
                            SymbolsFlag = true;
                        }
                        else//Symbol view was on
                        {
                            kv.Keyboard = keyboard;
                            kv.OnKeyboardActionListener = this;
                            SymbolsFlag = false;
                        }
                        break;
                    }

                    char code = (char)(primaryCode);



                    ic.CommitText(code.ToString(), 1);// to provides the keystroke to input area according to ascai value of code



                    break;

            }







        }





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

        public override void OnWindowShown()
        {
            // ShowGenericError("OnWindowShown Called");

           
           // ComitAutofill();
            base.OnWindowShown();
        }

        public override void OnWindowHidden()
        {
            ComitAutofill();
            ShowGenericError("Onwidnowhidden called");
            base.OnWindowHidden();
        }



        public void ShowGenericError(string title = "This feature is under construction")
        {
            Toast.MakeText(this, title, Android.Widget.ToastLength.Long).Show();
        }

        public void SwipeDown()
        {
            kv.Keyboard = keyboard;
            kv.OnKeyboardActionListener = this;
            CapsFlag = false;
        }

        public void SwipeLeft()
        {
        }

        public void SwipeRight() { }

        public void SwipeUp()
        {
            CapsKeyboard = new Keyboard(this, Resource.Xml.caps_qwerty);
            kv.Keyboard = CapsKeyboard;
            kv.OnKeyboardActionListener = this;
            CapsFlag = true;
        }






    }
}