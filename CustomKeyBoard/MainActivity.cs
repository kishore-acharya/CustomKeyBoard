using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.InputMethodServices;
using Android.Views;
using Java.Lang;
using Android.Views.InputMethods;

namespace CustomKeyBoard
{
    [Service(Permission = "android.permission.BIND_INPUT_METHOD", Label = "KishoreKeyboard")]
    [MetaData("android.view.im", Resource = "@xml/method")]
    [IntentFilter(new string[] { "android.view.InputMethod" })]
    public class MainActivity : InputMethodService, KeyboardView.IOnKeyboardActionListener
    {

        private KeyboardView kv;
        private Keyboard keyboard;
        private Keyboard CapsKeyboard;
        private bool CapsFlag = false;
        private string selectedText;


        public override View OnCreateInputView()
        {
            kv = (KeyboardView)LayoutInflater.Inflate(Resource.Layout.keyboard, null);
            keyboard = new Keyboard(this, Resource.Xml.qwerty);
            kv.Keyboard = keyboard;
            
            kv.SetPadding(5,5,5,5);
            kv.OnKeyboardActionListener = this;

            return kv;
            //return null;
            
        }

        public void OnKey([GeneratedEnum] Android.Views.Keycode primaryCode, [GeneratedEnum] Android.Views.Keycode[] keyCodes)
        {
            // throw new System.NotImplementedException();
            VibrateOnKey(15);
            var ic = CurrentInputConnection;//to get current input connection
            
            if (ic == null)
                return;
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
                    else//caps lock was already on
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
                case (Android.Views.Keycode.C)://this is because ASCII value 115 for C is same as android enum for backspace
                {
                    ic.CommitText("C", 1);
                    break;
                }

                default:
                    char code = (char)(primaryCode);
                   
                    ic.CommitText(code.ToString(), 1);// to provides the keystroke to input area according to ascai value of code
                   
                    break;
            }


        }
        // to vibrate on key press
        private void VibrateOnKey(int ms)
        {
            if (Build.VERSION.SdkInt >= (BuildVersionCodes) 26)
            {
                ((Vibrator)GetSystemService(VibratorService)).Vibrate(VibrationEffect.CreateOneShot(ms, 2));
            }
            else
            {
                ((Vibrator)GetSystemService(VibratorService)).Vibrate(ms);
            }
        }

        public void OnPress(int primaryCode)
        {
          //  VibrateOnKey(20);
        }

       
        public void OnRelease(int primaryCode) { }


       
        public void SwipeLeft() { }

       
        public void SwipeRight() { }

       
        public void SwipeDown() { }

       
        public void SwipeUp() { }

      

        public void OnPress([GeneratedEnum] Android.Views.Keycode primaryCode)
        {
           // throw new System.NotImplementedException();
        }

        public void OnRelease([GeneratedEnum] Android.Views.Keycode primaryCode)
        {
            //throw new System.NotImplementedException();
        }

        public void OnText(ICharSequence text)
        {
            //throw new System.NotImplementedException();
        }
    }
}