using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.InputMethodServices;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Accessibility;
using Android.Views.Animations;
using Android.Views.Autofill;
using Android.Views.InputMethods;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace CustomKeyBoard
{
    public class KishoreKeyboardView : Android.InputMethodServices.KeyboardView
    {

        //public override bool OnKeyPreIme([GeneratedEnum] Android.Views.Keycode keyCode, KeyEvent e)//My main change bug 100
        //{

        //    Console.WriteLine("OnKeyPreIme invoke, value recieved is " + (int)keyCode);
        //    if ((int)keyCode == 118)
        //    {
        //        PreviewEnabled = false;
        //        Console.WriteLine("OnKeyPreIme invoke if, value recieved is " + (int)keyCode);
        //        return base.OnKeyPreIme(keyCode, e);
        //    }
        //    else
        //    {
        //        PreviewEnabled = false;
        //        Console.WriteLine("OnKeyPreIme invoke else, value recieved is " + (int)keyCode);
        //        return base.OnKeyPreIme(keyCode, e);
                
        //    }
           
        //}
        public KishoreKeyboardView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            PreviewEnabled = true;
        }

        public KishoreKeyboardView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public KishoreKeyboardView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected KishoreKeyboardView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override ICharSequence AccessibilityClassNameFormatted => base.AccessibilityClassNameFormatted;

        public override AccessibilityLiveRegion AccessibilityLiveRegion { get => base.AccessibilityLiveRegion; set => base.AccessibilityLiveRegion = value; }

        public override AccessibilityNodeProvider AccessibilityNodeProvider => base.AccessibilityNodeProvider;

        public override int AccessibilityTraversalAfter { get => base.AccessibilityTraversalAfter; set => base.AccessibilityTraversalAfter = value; }
        public override int AccessibilityTraversalBefore { get => base.AccessibilityTraversalBefore; set => base.AccessibilityTraversalBefore = value; }
        public override bool Activated { get => base.Activated; set => base.Activated = value; }
        public override float Alpha { get => base.Alpha; set => base.Alpha = value; }
        public override Animation Animation { get => base.Animation; set => base.Animation = value; }

        public override IBinder ApplicationWindowToken => base.ApplicationWindowToken;

        public override AutofillType AutofillType => base.AutofillType;

        public override AutofillValue AutofillValue => base.AutofillValue;

        public override Drawable Background { get => base.Background; set => base.Background = value; }
        public override ColorStateList BackgroundTintList { get => base.BackgroundTintList; set => base.BackgroundTintList = value; }
        public override PorterDuff.Mode BackgroundTintMode { get => base.BackgroundTintMode; set => base.BackgroundTintMode = value; }

        public override int Baseline => base.Baseline;

        public override float CameraDistance => base.CameraDistance;

        public override bool Clickable { get => base.Clickable; set => base.Clickable = value; }
        public override Rect ClipBounds { get => base.ClipBounds; set => base.ClipBounds = value; }
        public override ICharSequence ContentDescriptionFormatted { get => base.ContentDescriptionFormatted; set => base.ContentDescriptionFormatted = value; }
        public override bool ContextClickable { get => base.ContextClickable; set => base.ContextClickable = value; }

        public override Display Display => base.Display;

        public override Bitmap DrawingCache => base.DrawingCache;

        public override Color DrawingCacheBackgroundColor { get => base.DrawingCacheBackgroundColor; set => base.DrawingCacheBackgroundColor = value; }
        public override bool DrawingCacheEnabled { get => base.DrawingCacheEnabled; set => base.DrawingCacheEnabled = value; }
        public override DrawingCacheQuality DrawingCacheQuality { get => base.DrawingCacheQuality; set => base.DrawingCacheQuality = value; }

        public override long DrawingTime => base.DrawingTime;

        public override bool DuplicateParentStateEnabled { get => base.DuplicateParentStateEnabled; set => base.DuplicateParentStateEnabled = value; }
        public override float Elevation { get => base.Elevation; set => base.Elevation = value; }
        public override bool Enabled { get => base.Enabled; set => base.Enabled = value; }
        public override bool FilterTouchesWhenObscured { get => base.FilterTouchesWhenObscured; set => base.FilterTouchesWhenObscured = value; }

        public override bool FitsSystemWindows => base.FitsSystemWindows;

        public override Drawable Foreground { get => base.Foreground; set => base.Foreground = value; }

        public override GravityFlags ForegroundGravity => base.ForegroundGravity;

        public override ColorStateList ForegroundTintList { get => base.ForegroundTintList; set => base.ForegroundTintList = value; }
        public override PorterDuff.Mode ForegroundTintMode { get => base.ForegroundTintMode; set => base.ForegroundTintMode = value; }

        public override Handler Handler => base.Handler;

        public override bool HapticFeedbackEnabled { get => base.HapticFeedbackEnabled; set => base.HapticFeedbackEnabled = value; }

        public override bool HasExplicitFocusable => base.HasExplicitFocusable;

        public override bool HasFocus => base.HasFocus;

        public override bool HasFocusable => base.HasFocusable;

        public override bool HasNestedScrollingParent => base.HasNestedScrollingParent;

        public override bool HasOnClickListeners => base.HasOnClickListeners;

        public override bool HasOverlappingRendering => base.HasOverlappingRendering;

        public override bool HasPointerCapture => base.HasPointerCapture;

        public override bool HasTransientState { get => base.HasTransientState; set => base.HasTransientState = value; }

        public override bool HasWindowFocus => base.HasWindowFocus;

        public override bool HorizontalFadingEdgeEnabled { get => base.HorizontalFadingEdgeEnabled; set => base.HorizontalFadingEdgeEnabled = value; }

        public override int HorizontalFadingEdgeLength => base.HorizontalFadingEdgeLength;

        public override bool HorizontalScrollBarEnabled { get => base.HorizontalScrollBarEnabled; set => base.HorizontalScrollBarEnabled = value; }
        public override bool Hovered { get => base.Hovered; set => base.Hovered = value; }
        public override int Id { get => base.Id; set => base.Id = value; }
        public override ImportantForAccessibility ImportantForAccessibility { get => base.ImportantForAccessibility; set => base.ImportantForAccessibility = value; }
        public override ImportantForAutofill ImportantForAutofill { get => base.ImportantForAutofill; set => base.ImportantForAutofill = value; }

        public override bool IsAccessibilityFocused => base.IsAccessibilityFocused;

        public override bool IsAttachedToWindow => base.IsAttachedToWindow;

        public override bool IsDirty => base.IsDirty;

        public override bool IsFocused => base.IsFocused;

        public override bool IsHardwareAccelerated => base.IsHardwareAccelerated;

        public override bool IsImportantForAccessibility => base.IsImportantForAccessibility;

        public override bool IsInEditMode => base.IsInEditMode;

        public override bool IsInLayout => base.IsInLayout;

        public override bool IsInTouchMode => base.IsInTouchMode;

        public override bool IsLaidOut => base.IsLaidOut;

        public override bool IsLayoutDirectionResolved => base.IsLayoutDirectionResolved;

        public override bool IsLayoutRequested => base.IsLayoutRequested;

        public override bool IsOpaque => base.IsOpaque;

        public override bool IsPaddingRelative => base.IsPaddingRelative;

        public override bool IsScrollContainer => base.IsScrollContainer;

        public override bool IsShown => base.IsShown;

        public override bool IsTextAlignmentResolved => base.IsTextAlignmentResolved;

        public override bool IsTextDirectionResolved => base.IsTextDirectionResolved;

        public override bool KeepScreenOn { get => base.KeepScreenOn; set => base.KeepScreenOn = value; }

        public override KeyEvent.DispatcherState KeyDispatcherState => base.KeyDispatcherState;

        public override int LabelFor { get => base.LabelFor; set => base.LabelFor = value; }

        public override LayerType LayerType => base.LayerType;

        public override Android.Views.LayoutDirection LayoutDirection { get => base.LayoutDirection; set => base.LayoutDirection = value; }
        public override ViewGroup.LayoutParams LayoutParameters { get => base.LayoutParameters; set => base.LayoutParameters = value; }
        public override bool LongClickable { get => base.LongClickable; set => base.LongClickable = value; }

        public override Matrix Matrix => base.Matrix;

        public override int MinimumHeight => base.MinimumHeight;

        public override int MinimumWidth => base.MinimumWidth;

        public override bool NestedScrollingEnabled { get => base.NestedScrollingEnabled; set => base.NestedScrollingEnabled = value; }
        public override int NextClusterForwardId { get => base.NextClusterForwardId; set => base.NextClusterForwardId = value; }
        public override int NextFocusDownId { get => base.NextFocusDownId; set => base.NextFocusDownId = value; }
        public override int NextFocusForwardId { get => base.NextFocusForwardId; set => base.NextFocusForwardId = value; }
        public override int NextFocusLeftId { get => base.NextFocusLeftId; set => base.NextFocusLeftId = value; }
        public override int NextFocusRightId { get => base.NextFocusRightId; set => base.NextFocusRightId = value; }
        public override int NextFocusUpId { get => base.NextFocusUpId; set => base.NextFocusUpId = value; }
        public override IOnFocusChangeListener OnFocusChangeListener { get => base.OnFocusChangeListener; set => base.OnFocusChangeListener = value; }
        public override ViewOutlineProvider OutlineProvider { get => base.OutlineProvider; set => base.OutlineProvider = value; }
        public override OverScrollMode OverScrollMode { get => base.OverScrollMode; set => base.OverScrollMode = value; }

        public override ViewOverlay Overlay => base.Overlay;

        public override int PaddingBottom => base.PaddingBottom;

        public override int PaddingEnd => base.PaddingEnd;

        public override int PaddingLeft => base.PaddingLeft;

        public override int PaddingRight => base.PaddingRight;

        public override int PaddingStart => base.PaddingStart;

        public override int PaddingTop => base.PaddingTop;

        public override IViewParent ParentForAccessibility => base.ParentForAccessibility;

        public override float PivotX { get => base.PivotX; set => base.PivotX = value; }
        public override float PivotY { get => base.PivotY; set => base.PivotY = value; }
        public override PointerIcon PointerIcon { get => base.PointerIcon; set => base.PointerIcon = value; }
        public override bool Pressed { get => base.Pressed; set => base.Pressed = value; }

        public override Resources Resources => base.Resources;

        public override View RootView => base.RootView;

        public override WindowInsets RootWindowInsets => base.RootWindowInsets;

        public override float Rotation { get => base.Rotation; set => base.Rotation = value; }
        public override float RotationX { get => base.RotationX; set => base.RotationX = value; }
        public override float RotationY { get => base.RotationY; set => base.RotationY = value; }
        public override bool SaveEnabled { get => base.SaveEnabled; set => base.SaveEnabled = value; }
        public override bool SaveFromParentEnabled { get => base.SaveFromParentEnabled; set => base.SaveFromParentEnabled = value; }
        public override float ScaleX { get => base.ScaleX; set => base.ScaleX = value; }
        public override float ScaleY { get => base.ScaleY; set => base.ScaleY = value; }
        public override int ScrollBarDefaultDelayBeforeFade { get => base.ScrollBarDefaultDelayBeforeFade; set => base.ScrollBarDefaultDelayBeforeFade = value; }
        public override int ScrollBarFadeDuration { get => base.ScrollBarFadeDuration; set => base.ScrollBarFadeDuration = value; }
        public override int ScrollBarSize { get => base.ScrollBarSize; set => base.ScrollBarSize = value; }
        public override ScrollbarStyles ScrollBarStyle { get => base.ScrollBarStyle; set => base.ScrollBarStyle = value; }

        public override ScrollIndicatorPosition ScrollIndicators => base.ScrollIndicators;

        public override bool ScrollbarFadingEnabled { get => base.ScrollbarFadingEnabled; set => base.ScrollbarFadingEnabled = value; }
        public override bool Selected { get => base.Selected; set => base.Selected = value; }

        public override int SolidColor => base.SolidColor;

        public override bool SoundEffectsEnabled { get => base.SoundEffectsEnabled; set => base.SoundEffectsEnabled = value; }
        public override StateListAnimator StateListAnimator { get => base.StateListAnimator; set => base.StateListAnimator = value; }
        public override StatusBarVisibility SystemUiVisibility { get => base.SystemUiVisibility; set => base.SystemUiVisibility = value; }
        public override Java.Lang.Object Tag { get => base.Tag; set => base.Tag = value; }
        public override TextAlignment TextAlignment { get => base.TextAlignment; set => base.TextAlignment = value; }
        public override TextDirection TextDirection { get => base.TextDirection; set => base.TextDirection = value; }
        public override ICharSequence TooltipTextFormatted { get => base.TooltipTextFormatted; set => base.TooltipTextFormatted = value; }
        public override TouchDelegate TouchDelegate { get => base.TouchDelegate; set => base.TouchDelegate = value; }

        public override IList<View> Touchables => base.Touchables;

        public override float TranslationX { get => base.TranslationX; set => base.TranslationX = value; }
        public override float TranslationY { get => base.TranslationY; set => base.TranslationY = value; }
        public override float TranslationZ { get => base.TranslationZ; set => base.TranslationZ = value; }
        public override bool VerticalFadingEdgeEnabled { get => base.VerticalFadingEdgeEnabled; set => base.VerticalFadingEdgeEnabled = value; }

        public override int VerticalFadingEdgeLength => base.VerticalFadingEdgeLength;

        public override bool VerticalScrollBarEnabled { get => base.VerticalScrollBarEnabled; set => base.VerticalScrollBarEnabled = value; }
        public override ScrollbarPosition VerticalScrollbarPosition { get => base.VerticalScrollbarPosition; set => base.VerticalScrollbarPosition = value; }

        public override int VerticalScrollbarWidth => base.VerticalScrollbarWidth;

        public override ViewTreeObserver ViewTreeObserver => base.ViewTreeObserver;

        public override ViewStates Visibility { get => base.Visibility; set => base.Visibility = value; }

        public override WindowId WindowId => base.WindowId;

        public override SystemUiFlags WindowSystemUiVisibility => base.WindowSystemUiVisibility;

        public override IBinder WindowToken => base.WindowToken;

        public override ViewStates WindowVisibility => base.WindowVisibility;

        public override JniPeerMembers JniPeerMembers => base.JniPeerMembers;

        public override bool IsShifted => base.IsShifted;

        public override Keyboard Keyboard { get => base.Keyboard; set => base.Keyboard = value; }
        public override IOnKeyboardActionListener OnKeyboardActionListener { get => base.OnKeyboardActionListener; set => base.OnKeyboardActionListener = value; }
        public override bool PreviewEnabled { get => base.PreviewEnabled; set => base.PreviewEnabled = value; }
        public override bool ProximityCorrectionEnabled { get => base.ProximityCorrectionEnabled; set => base.ProximityCorrectionEnabled = value; }

        protected override float BottomFadingEdgeStrength => base.BottomFadingEdgeStrength;

        protected override int BottomPaddingOffset => base.BottomPaddingOffset;

        protected override IContextMenuContextMenuInfo ContextMenuInfo => base.ContextMenuInfo;

        protected override int HorizontalScrollbarHeight => base.HorizontalScrollbarHeight;

        protected override bool IsPaddingOffsetRequired => base.IsPaddingOffsetRequired;

        protected override float LeftFadingEdgeStrength => base.LeftFadingEdgeStrength;

        protected override int LeftPaddingOffset => base.LeftPaddingOffset;

        protected override float RightFadingEdgeStrength => base.RightFadingEdgeStrength;

        protected override int RightPaddingOffset => base.RightPaddingOffset;

        protected override int SuggestedMinimumHeight => base.SuggestedMinimumHeight;

        protected override int SuggestedMinimumWidth => base.SuggestedMinimumWidth;

        protected override float TopFadingEdgeStrength => base.TopFadingEdgeStrength;

        protected override int TopPaddingOffset => base.TopPaddingOffset;

        protected override int WindowAttachCount => base.WindowAttachCount;

        protected override IntPtr ThresholdClass => base.ThresholdClass;

        protected override Type ThresholdType => base.ThresholdType;

        public override void AddChildrenForAccessibility(IList<View> outChildren)
        {
            base.AddChildrenForAccessibility(outChildren);
        }

        public override void AddExtraDataToAccessibilityNodeInfo(AccessibilityNodeInfo info, string extraDataKey, Bundle arguments)
        {
            base.AddExtraDataToAccessibilityNodeInfo(info, extraDataKey, arguments);
        }

        public override void AddFocusables(IList<View> views, [GeneratedEnum] FocusSearchDirection direction)
        {
            base.AddFocusables(views, direction);
        }

        public override void AddFocusables(IList<View> views, [GeneratedEnum] FocusSearchDirection direction, [GeneratedEnum] FocusablesFlags focusableMode)
        {
            base.AddFocusables(views, direction, focusableMode);
        }

        public override void AddKeyboardNavigationClusters(ICollection<View> views, [GeneratedEnum] FocusSearchDirection direction)
        {
            base.AddKeyboardNavigationClusters(views, direction);
        }

        public override void AddOnAttachStateChangeListener(IOnAttachStateChangeListener listener)
        {
            base.AddOnAttachStateChangeListener(listener);
        }

        public override void AddOnLayoutChangeListener(IOnLayoutChangeListener listener)
        {
            base.AddOnLayoutChangeListener(listener);
        }

        public override void AddTouchables(IList<View> views)
        {
            base.AddTouchables(views);
        }

        public override ViewPropertyAnimator Animate()
        {
            return base.Animate();
        }

        public override void AnnounceForAccessibility(ICharSequence text)
        {
            base.AnnounceForAccessibility(text);
        }

        public override void Autofill(SparseArray values)
        {
            base.Autofill(values);
        }

        public override void Autofill(AutofillValue value)
        {
            base.Autofill(value);
        }

        public override void BringToFront()
        {
            base.BringToFront();
        }

        public override void BuildDrawingCache()
        {
            base.BuildDrawingCache();
        }

        public override void BuildDrawingCache(bool autoScale)
        {
            base.BuildDrawingCache(autoScale);
        }

        public override void BuildLayer()
        {
            base.BuildLayer();
        }

        public override bool CallOnClick()
        {
            return base.CallOnClick();
        }

        public override void CancelLongPress()
        {
            base.CancelLongPress();
        }

        public override bool CanResolveLayoutDirection()
        {
            return base.CanResolveLayoutDirection();
        }

        public override bool CanResolveTextAlignment()
        {
            return base.CanResolveTextAlignment();
        }

        public override bool CanResolveTextDirection()
        {
            return base.CanResolveTextDirection();
        }

        public override bool CanScrollHorizontally(int direction)
        {
            return base.CanScrollHorizontally(direction);
        }

        public override bool CanScrollVertically(int direction)
        {
            return base.CanScrollVertically(direction);
        }

        public override bool CheckInputConnectionProxy(View view)
        {
            return base.CheckInputConnectionProxy(view);
        }

        public override void ClearAnimation()
        {
            base.ClearAnimation();
        }

        public override void ClearFocus()
        {
            base.ClearFocus();
        }

        public override void Closing()
        {
            base.Closing();
        }

        public override void ComputeScroll()
        {
            base.ComputeScroll();
        }

        public override WindowInsets ComputeSystemWindowInsets(WindowInsets @in, Rect outLocalInsets)
        {
            return base.ComputeSystemWindowInsets(@in, outLocalInsets);
        }

        public override AccessibilityNodeInfo CreateAccessibilityNodeInfo()
        {
            return base.CreateAccessibilityNodeInfo();
        }

        public override void CreateContextMenu(IContextMenu menu)
        {
            base.CreateContextMenu(menu);
        }

        public override void DestroyDrawingCache()
        {
            base.DestroyDrawingCache();
        }

        public override WindowInsets DispatchApplyWindowInsets(WindowInsets insets)
        {
            return base.DispatchApplyWindowInsets(insets);
        }

        public override bool DispatchCapturedPointerEvent(MotionEvent e)
        {
            return base.DispatchCapturedPointerEvent(e);
        }

        public override void DispatchConfigurationChanged(Configuration newConfig)
        {
            base.DispatchConfigurationChanged(newConfig);
        }

        public override void DispatchDisplayHint([GeneratedEnum] ViewStates hint)
        {
            base.DispatchDisplayHint(hint);
        }

        public override bool DispatchDragEvent(DragEvent e)
        {
          
            return base.DispatchDragEvent(e);
        }

        public override void DispatchDrawableHotspotChanged(float x, float y)
        {
            base.DispatchDrawableHotspotChanged(x, y);
        }

        public override void DispatchFinishTemporaryDetach()
        {
            base.DispatchFinishTemporaryDetach();
        }

        public override bool DispatchGenericMotionEvent(MotionEvent e)
        {
            return base.DispatchGenericMotionEvent(e);
        }

        public override bool DispatchKeyEvent(KeyEvent e)
        {
            return base.DispatchKeyEvent(e);
        }

        public override bool DispatchKeyEventPreIme(KeyEvent e)
        {
            return base.DispatchKeyEventPreIme(e);
        }

        public override bool DispatchKeyShortcutEvent(KeyEvent e)
        {
            return base.DispatchKeyShortcutEvent(e);
        }

        public override bool DispatchNestedFling(float velocityX, float velocityY, bool consumed)
        {
            return base.DispatchNestedFling(velocityX, velocityY, consumed);
        }

        public override bool DispatchNestedPreFling(float velocityX, float velocityY)
        {
            return base.DispatchNestedPreFling(velocityX, velocityY);
        }

        public override bool DispatchNestedPrePerformAccessibilityAction([GeneratedEnum] Android.Views.Accessibility.Action action, Bundle arguments)
        {
            return base.DispatchNestedPrePerformAccessibilityAction(action, arguments);
        }

        public override bool DispatchNestedPreScroll(int dx, int dy, int[] consumed, int[] offsetInWindow)
        {
            return base.DispatchNestedPreScroll(dx, dy, consumed, offsetInWindow);
        }

        public override bool DispatchNestedScroll(int dxConsumed, int dyConsumed, int dxUnconsumed, int dyUnconsumed, int[] offsetInWindow)
        {
            return base.DispatchNestedScroll(dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, offsetInWindow);
        }

        public override void DispatchPointerCaptureChanged(bool hasCapture)
        {
            base.DispatchPointerCaptureChanged(hasCapture);
        }

        public override bool DispatchPopulateAccessibilityEvent(AccessibilityEvent e)
        {
            return base.DispatchPopulateAccessibilityEvent(e);
        }

        public override void DispatchProvideAutofillStructure(ViewStructure structure, [GeneratedEnum] AutofillFlags flags)
        {
            base.DispatchProvideAutofillStructure(structure, flags);
        }

        public override void DispatchProvideStructure(ViewStructure structure)
        {
            base.DispatchProvideStructure(structure);
        }

        public override void DispatchStartTemporaryDetach()
        {
            base.DispatchStartTemporaryDetach();
        }

        public override void DispatchSystemUiVisibilityChanged([GeneratedEnum] SystemUiFlags visibility)
        {
            base.DispatchSystemUiVisibilityChanged(visibility);
        }

        public override bool DispatchTouchEvent(MotionEvent e)
        {
            return base.DispatchTouchEvent(e);
        }

        public override bool DispatchTrackballEvent(MotionEvent e)
        {
            return base.DispatchTrackballEvent(e);
        }

        public override bool DispatchUnhandledMove(View focused, [GeneratedEnum] FocusSearchDirection direction)
        {
            return base.DispatchUnhandledMove(focused, direction);
        }

        public override void DispatchWindowFocusChanged(bool hasFocus)
        {
            base.DispatchWindowFocusChanged(hasFocus);
        }

        public override void DispatchWindowSystemUiVisiblityChanged([GeneratedEnum] SystemUiFlags visible)
        {
            base.DispatchWindowSystemUiVisiblityChanged(visible);
        }

        public override void DispatchWindowVisibilityChanged([GeneratedEnum] ViewStates visibility)
        {
            base.DispatchWindowVisibilityChanged(visibility);
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
        }

        public override void DrawableHotspotChanged(float x, float y)
        {
            base.DrawableHotspotChanged(x, y);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override bool Equals(Java.Lang.Object obj)
        {
            return base.Equals(obj);
        }

        public override View FindFocus()
        {
            return base.FindFocus();
        }

        public override void FindViewsWithText(IList<View> outViews, ICharSequence searched, [GeneratedEnum] FindViewsWith flags)
        {
            base.FindViewsWithText(outViews, searched, flags);
        }

        public override View FocusSearch([GeneratedEnum] FocusSearchDirection direction)
        {
            return base.FocusSearch(direction);
        }

        public override void ForceHasOverlappingRendering(bool hasOverlappingRendering)
        {
            base.ForceHasOverlappingRendering(hasOverlappingRendering);
        }

        public override void ForceLayout()
        {
            base.ForceLayout();
        }

        public override string[] GetAutofillHints()
        {
            return base.GetAutofillHints();
        }

        public override bool GetClipBounds(Rect outRect)
        {
            return base.GetClipBounds(outRect);
        }

        public override Bitmap GetDrawingCache(bool autoScale)
        {
            return base.GetDrawingCache(autoScale);
        }

        public override void GetDrawingRect(Rect outRect)
        {
            base.GetDrawingRect(outRect);
        }

        [return: GeneratedEnum]
        public override ViewFocusability GetFocusable()
        {
            return base.GetFocusable();
        }

        public override IList<View> GetFocusables([GeneratedEnum] FocusSearchDirection direction)
        {
            return base.GetFocusables(direction);
        }

        public override void GetFocusedRect(Rect r)
        {
            base.GetFocusedRect(r);
        }

        public override bool GetGlobalVisibleRect(Rect r, Point globalOffset)
        {
            return base.GetGlobalVisibleRect(r, globalOffset);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void GetHitRect(Rect outRect)
        {
            base.GetHitRect(outRect);
        }

        public override void GetLocationInWindow(int[] outLocation)
        {
            base.GetLocationInWindow(outLocation);
        }

        public override void GetLocationOnScreen(int[] outLocation)
        {
            base.GetLocationOnScreen(outLocation);
        }

        public override Java.Lang.Object GetTag(int key)
        {
            return base.GetTag(key);
        }

        public override void GetWindowVisibleDisplayFrame(Rect outRect)
        {
            base.GetWindowVisibleDisplayFrame(outRect);
        }

        public override float GetX()
        {
            return base.GetX();
        }

        public override float GetY()
        {
            return base.GetY();
        }

        public override float GetZ()
        {
            return base.GetZ();
        }

        public override bool HandleBack()
        {
            return base.HandleBack();
        }

        public override void Invalidate()
        {
            base.Invalidate();
        }

        public override void Invalidate(Rect dirty)
        {
            base.Invalidate(dirty);
        }

        public override void Invalidate(int l, int t, int r, int b)
        {
            base.Invalidate(l, t, r, b);
        }

        public override void InvalidateAllKeys()
        {
            base.InvalidateAllKeys();
        }

        public override void InvalidateDrawable(Drawable drawable)
        {
            base.InvalidateDrawable(drawable);
        }

        public override void InvalidateKey(int keyIndex)
        {
            base.InvalidateKey(keyIndex);
        }

        public override void InvalidateOutline()
        {
            base.InvalidateOutline();
        }

        public override bool InvokeFitsSystemWindows()
        {
            return base.InvokeFitsSystemWindows();
        }

        public override void JumpDrawablesToCurrentState()
        {
            base.JumpDrawablesToCurrentState();
        }

        public override View KeyboardNavigationClusterSearch(View currentCluster, [GeneratedEnum] FocusSearchDirection direction)
        {
            return base.KeyboardNavigationClusterSearch(currentCluster, direction);
        }

        public override void Layout(int l, int t, int r, int b)
        {
            base.Layout(l, t, r, b);
        }

        public override void OffsetLeftAndRight(int offset)
        {
            base.OffsetLeftAndRight(offset);
        }

        public override void OffsetTopAndBottom(int offset)
        {
            base.OffsetTopAndBottom(offset);
        }

        public override WindowInsets OnApplyWindowInsets(WindowInsets insets)
        {
            return base.OnApplyWindowInsets(insets);
        }

        public override void OnCancelPendingInputEvents()
        {
            base.OnCancelPendingInputEvents();
        }

        public override bool OnCapturedPointerEvent(MotionEvent e)
        {
            return base.OnCapturedPointerEvent(e);
        }

        public override bool OnCheckIsTextEditor()
        {
            return base.OnCheckIsTextEditor();
        }

        public override void OnClick(View v)
        {
            base.OnClick(v);
        }

        public override IInputConnection OnCreateInputConnection(EditorInfo outAttrs)
        {
            return base.OnCreateInputConnection(outAttrs);
        }

        public override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
        }

        public override bool OnDragEvent(DragEvent e)
        {
            return base.OnDragEvent(e);
        }

        public override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
        }

        public override void OnDrawForeground(Canvas canvas)
        {
            base.OnDrawForeground(canvas);
        }

        public override bool OnFilterTouchEventForSecurity(MotionEvent e)
        {
            return base.OnFilterTouchEventForSecurity(e);
        }

        public override void OnFinishTemporaryDetach()
        {
            base.OnFinishTemporaryDetach();
        }

        public override bool OnGenericMotionEvent(MotionEvent e)
        {
            return base.OnGenericMotionEvent(e);
        }

        public override void OnHoverChanged(bool hovered)
        {
            base.OnHoverChanged(hovered);
        }

        public override bool OnHoverEvent(MotionEvent e)
        {
            return base.OnHoverEvent(e);
        }

        public override void OnInitializeAccessibilityEvent(AccessibilityEvent e)
        {
            base.OnInitializeAccessibilityEvent(e);
        }

        public override void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo info)
        {
            base.OnInitializeAccessibilityNodeInfo(info);
        }

        public override bool OnKeyDown([GeneratedEnum] Android.Views.Keycode keyCode, KeyEvent e)
        {
            PreviewEnabled = false;//bug 100
            return base.OnKeyDown(keyCode, e);
        }

        public override bool OnKeyLongPress([GeneratedEnum] Android.Views.Keycode keyCode, KeyEvent e)
        {
            PreviewEnabled = false;
            return base.OnKeyLongPress(keyCode, e);
        }

        public override bool OnKeyMultiple([GeneratedEnum] Android.Views.Keycode keyCode, int repeatCount, KeyEvent e)
        {
            return base.OnKeyMultiple(keyCode, repeatCount, e);
        }

       

        public override bool OnKeyShortcut([GeneratedEnum] Android.Views.Keycode keyCode, KeyEvent e)
        {
            return base.OnKeyShortcut(keyCode, e);
        }

        public override bool OnKeyUp([GeneratedEnum] Android.Views.Keycode keyCode, KeyEvent e)
        {
            return base.OnKeyUp(keyCode, e);
        }

        public override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }

        public override void OnPointerCaptureChange(bool hasCapture)
        {
            base.OnPointerCaptureChange(hasCapture);
        }

        public override void OnPopulateAccessibilityEvent(AccessibilityEvent e)
        {
            base.OnPopulateAccessibilityEvent(e);
        }

        public override void OnProvideAutofillStructure(ViewStructure structure, [GeneratedEnum] AutofillFlags flags)
        {
            base.OnProvideAutofillStructure(structure, flags);
        }

        public override void OnProvideAutofillVirtualStructure(ViewStructure structure, [GeneratedEnum] AutofillFlags flags)
        {
            base.OnProvideAutofillVirtualStructure(structure, flags);
        }

        public override void OnProvideStructure(ViewStructure structure)
        {
            base.OnProvideStructure(structure);
        }

        public override void OnProvideVirtualStructure(ViewStructure structure)
        {
            base.OnProvideVirtualStructure(structure);
        }

        public override PointerIcon OnResolvePointerIcon(MotionEvent e, int pointerIndex)
        {
            return base.OnResolvePointerIcon(e, pointerIndex);
        }

        public override void OnRtlPropertiesChanged([GeneratedEnum] Android.Views.LayoutDirection layoutDirection)
        {
            base.OnRtlPropertiesChanged(layoutDirection);
        }

        public override void OnScreenStateChanged([GeneratedEnum] ScreenState screenState)
        {
            base.OnScreenStateChanged(screenState);
        }

        public override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
        }

        public override void OnStartTemporaryDetach()
        {
            base.OnStartTemporaryDetach();
        }

        public override bool OnTouchEvent(MotionEvent e)//seems to actualy working for bug 100
        {
            if (e.Action== MotionEventActions.Move)
            {
                PreviewEnabled = false;
            }
            if (e.Action == MotionEventActions.Up)
            {
                PreviewEnabled = true;
            }

            return base.OnTouchEvent(e);
        }

        public override bool OnTrackballEvent(MotionEvent e)
        {
            return base.OnTrackballEvent(e);
        }

        public override void OnVisibilityAggregated(bool isVisible)
        {
            base.OnVisibilityAggregated(isVisible);
        }

        public override void OnWindowFocusChanged(bool hasWindowFocus)
        {
            base.OnWindowFocusChanged(hasWindowFocus);
        }

        public override void OnWindowSystemUiVisibilityChanged([GeneratedEnum] SystemUiFlags visible)
        {
            base.OnWindowSystemUiVisibilityChanged(visible);
        }

        public override bool PerformAccessibilityAction([GeneratedEnum] Android.Views.Accessibility.Action action, Bundle arguments)
        {
            return base.PerformAccessibilityAction(action, arguments);
        }

        public override bool PerformClick()
        {
            return base.PerformClick();
        }

        public override bool PerformContextClick()
        {
            return base.PerformContextClick();
        }

        public override bool PerformContextClick(float x, float y)
        {
            return base.PerformContextClick(x, y);
        }

        public override bool PerformHapticFeedback([GeneratedEnum] FeedbackConstants feedbackConstant)
        {
            return base.PerformHapticFeedback(feedbackConstant);
        }

        public override bool PerformHapticFeedback([GeneratedEnum] FeedbackConstants feedbackConstant, [GeneratedEnum] FeedbackFlags flags)
        {
            return base.PerformHapticFeedback(feedbackConstant, flags);
        }

        public override bool PerformLongClick()
        {
            return base.PerformLongClick();
        }

        public override bool PerformLongClick(float x, float y)
        {
            return base.PerformLongClick(x, y);
        }

        public override void PlaySoundEffect([GeneratedEnum] SoundEffects soundConstant)
        {
            base.PlaySoundEffect(soundConstant);
        }

        public override bool Post(IRunnable action)
        {
            return base.Post(action);
        }

        public override bool PostDelayed(IRunnable action, long delayMillis)
        {
            return base.PostDelayed(action, delayMillis);
        }

        public override void PostInvalidate()
        {
            base.PostInvalidate();
        }

        public override void PostInvalidate(int left, int top, int right, int bottom)
        {
            base.PostInvalidate(left, top, right, bottom);
        }

        public override void PostInvalidateDelayed(long delayMilliseconds)
        {
            base.PostInvalidateDelayed(delayMilliseconds);
        }

        public override void PostInvalidateDelayed(long delayMilliseconds, int left, int top, int right, int bottom)
        {
            base.PostInvalidateDelayed(delayMilliseconds, left, top, right, bottom);
        }

        public override void PostInvalidateOnAnimation()
        {
            base.PostInvalidateOnAnimation();
        }

        public override void PostInvalidateOnAnimation(int left, int top, int right, int bottom)
        {
            base.PostInvalidateOnAnimation(left, top, right, bottom);
        }

        public override void PostOnAnimation(IRunnable action)
        {
            base.PostOnAnimation(action);
        }

        public override void PostOnAnimationDelayed(IRunnable action, long delayMillis)
        {
            base.PostOnAnimationDelayed(action, delayMillis);
        }

        public override void RefreshDrawableState()
        {
            base.RefreshDrawableState();
        }

        public override void ReleasePointerCapture()
        {
            base.ReleasePointerCapture();
        }

        public override bool RemoveCallbacks(IRunnable action)
        {
            return base.RemoveCallbacks(action);
        }

        public override void RemoveOnAttachStateChangeListener(IOnAttachStateChangeListener listener)
        {
            base.RemoveOnAttachStateChangeListener(listener);
        }

        public override void RemoveOnLayoutChangeListener(IOnLayoutChangeListener listener)
        {
            base.RemoveOnLayoutChangeListener(listener);
        }

        public override void RequestApplyInsets()
        {
            base.RequestApplyInsets();
        }

        public override void RequestFitSystemWindows()
        {
            base.RequestFitSystemWindows();
        }

        public override bool RequestFocus([GeneratedEnum] FocusSearchDirection direction, Rect previouslyFocusedRect)
        {
            return base.RequestFocus(direction, previouslyFocusedRect);
        }

        public override void RequestLayout()
        {
            base.RequestLayout();
        }

        public override void RequestPointerCapture()
        {
            base.RequestPointerCapture();
        }

        public override bool RequestRectangleOnScreen(Rect rectangle)
        {
            return base.RequestRectangleOnScreen(rectangle);
        }

        public override bool RequestRectangleOnScreen(Rect rectangle, bool immediate)
        {
            return base.RequestRectangleOnScreen(rectangle, immediate);
        }

        public override bool RestoreDefaultFocus()
        {
            return base.RestoreDefaultFocus();
        }

        public override void RestoreHierarchyState(SparseArray container)
        {
            base.RestoreHierarchyState(container);
        }

        public override void SaveHierarchyState(SparseArray container)
        {
            base.SaveHierarchyState(container);
        }

        public override void ScheduleDrawable(Drawable who, IRunnable what, long when)
        {
            base.ScheduleDrawable(who, what, when);
        }

        public override void ScrollBy(int x, int y)
        {
            base.ScrollBy(x, y);
        }

        public override void ScrollTo(int x, int y)
        {
            base.ScrollTo(x, y);
        }

        public override void SendAccessibilityEvent([GeneratedEnum] EventTypes eventType)
        {
            base.SendAccessibilityEvent(eventType);
        }

        public override void SendAccessibilityEventUnchecked(AccessibilityEvent e)
        {
            base.SendAccessibilityEventUnchecked(e);
        }

        public override void SetAccessibilityDelegate(AccessibilityDelegate @delegate)
        {
            base.SetAccessibilityDelegate(@delegate);
        }

        public override void SetAutofillHints(params string[] autofillHints)
        {
            base.SetAutofillHints(autofillHints);
        }

        public override void SetBackgroundColor(Color color)
        {
            base.SetBackgroundColor(color);
        }

        public override void SetBackgroundDrawable(Drawable background)
        {
            base.SetBackgroundDrawable(background);
        }

        public override void SetBackgroundResource(int resid)
        {
            base.SetBackgroundResource(resid);
        }

        public override void SetCameraDistance(float distance)
        {
            base.SetCameraDistance(distance);
        }

        public override void SetFadingEdgeLength(int length)
        {
            base.SetFadingEdgeLength(length);
        }

        public override void SetFitsSystemWindows(bool fitSystemWindows)
        {
            base.SetFitsSystemWindows(fitSystemWindows);
        }

        public override void SetFocusable([GeneratedEnum] ViewFocusability focusable)
        {
            base.SetFocusable(focusable);
        }

        public override void SetForegroundGravity([GeneratedEnum] GravityFlags gravity)
        {
            base.SetForegroundGravity(gravity);
        }

        public override void SetLayerPaint(Paint paint)
        {
            base.SetLayerPaint(paint);
        }

        public override void SetLayerType([GeneratedEnum] LayerType layerType, Paint paint)
        {
            base.SetLayerType(layerType, paint);
        }

        public override void SetMinimumHeight(int minHeight)
        {
            base.SetMinimumHeight(minHeight);
        }

        public override void SetMinimumWidth(int minWidth)
        {
            base.SetMinimumWidth(minWidth);
        }

        public override void SetOnApplyWindowInsetsListener(IOnApplyWindowInsetsListener listener)
        {
            base.SetOnApplyWindowInsetsListener(listener);
        }

        public override void SetOnCapturedPointerListener(IOnCapturedPointerListener l)
        {
            base.SetOnCapturedPointerListener(l);
        }

        public override void SetOnClickListener(IOnClickListener l)
        {
            base.SetOnClickListener(l);
        }

        public override void SetOnContextClickListener(IOnContextClickListener l)
        {
            base.SetOnContextClickListener(l);
        }

        public override void SetOnCreateContextMenuListener(IOnCreateContextMenuListener l)
        {
            base.SetOnCreateContextMenuListener(l);
        }

        public override void SetOnDragListener(IOnDragListener l)
        {
            base.SetOnDragListener(l);
        }

        public override void SetOnGenericMotionListener(IOnGenericMotionListener l)
        {
            base.SetOnGenericMotionListener(l);
        }

        public override void SetOnHoverListener(IOnHoverListener l)
        {
            base.SetOnHoverListener(l);
        }

        public override void SetOnKeyListener(IOnKeyListener l)
        {
            base.SetOnKeyListener(l);
        }

        public override void SetOnLongClickListener(IOnLongClickListener l)
        {
            base.SetOnLongClickListener(l);
        }

        public override void SetOnScrollChangeListener(IOnScrollChangeListener l)
        {
            base.SetOnScrollChangeListener(l);
        }

        public override void SetOnSystemUiVisibilityChangeListener(IOnSystemUiVisibilityChangeListener l)
        {
            base.SetOnSystemUiVisibilityChangeListener(l);
        }

        public override void SetOnTouchListener(IOnTouchListener l)
        {
            base.SetOnTouchListener(l);
        }

        public override void SetPadding(int left, int top, int right, int bottom)
        {
            base.SetPadding(left, top, right, bottom);
        }

        public override void SetPaddingRelative(int start, int top, int end, int bottom)
        {
            base.SetPaddingRelative(start, top, end, bottom);
        }

        public override void SetPopupOffset(int x, int y)
        {
            base.SetPopupOffset(x, y);
        }

        public override void SetPopupParent(View v)
        {
            base.SetPopupParent(v);
        }

        public override void SetScrollContainer(bool isScrollContainer)
        {
            base.SetScrollContainer(isScrollContainer);
        }

        public override void SetScrollIndicators([IntDef(Flag = true, Type = "", Fields = new[] { "", "", "", "", "", "" })] int indicators)
        {
            base.SetScrollIndicators(indicators);
        }

        public override void SetScrollIndicators([IntDef(Flag = true, Type = "", Fields = new[] { "", "", "", "", "", "" })] int indicators, [IntDef(Flag = true, Type = "", Fields = new[] { "", "", "", "", "", "" })] int mask)
        {
            base.SetScrollIndicators(indicators, mask);
        }

        public override bool SetShifted(bool shifted)
        {
            return base.SetShifted(shifted);
        }

        public override void SetTag(int key, Java.Lang.Object tag)
        {
            base.SetTag(key, tag);
        }

        public override void SetVerticalCorrection(int verticalOffset)
        {
            base.SetVerticalCorrection(verticalOffset);
        }

        public override void SetWillNotCacheDrawing(bool willNotCacheDrawing)
        {
            base.SetWillNotCacheDrawing(willNotCacheDrawing);
        }

        public override void SetWillNotDraw(bool willNotDraw)
        {
            base.SetWillNotDraw(willNotDraw);
        }

        public override void SetX(float x)
        {
            base.SetX(x);
        }

        public override void SetY(float y)
        {
            base.SetY(y);
        }

        public override void SetZ(float z)
        {
            base.SetZ(z);
        }

        public override bool ShowContextMenu()
        {
            return base.ShowContextMenu();
        }

        public override bool ShowContextMenu(float x, float y)
        {
            return base.ShowContextMenu(x, y);
        }

        public override ActionMode StartActionMode(ActionMode.ICallback callback)
        {
            return base.StartActionMode(callback);
        }

        public override ActionMode StartActionMode(ActionMode.ICallback callback, [GeneratedEnum] ActionModeType type)
        {
            return base.StartActionMode(callback, type);
        }

        public override void StartAnimation(Animation animation)
        {
            base.StartAnimation(animation);
        }

        public override bool StartNestedScroll([GeneratedEnum] ScrollAxis axes)
        {
            return base.StartNestedScroll(axes);
        }

        public override void StopNestedScroll()
        {
            base.StopNestedScroll();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void UnscheduleDrawable(Drawable who)
        {
            base.UnscheduleDrawable(who);
        }

        public override void UnscheduleDrawable(Drawable who, IRunnable what)
        {
            base.UnscheduleDrawable(who, what);
        }

        public override bool WillNotCacheDrawing()
        {
            return base.WillNotCacheDrawing();
        }

        public override bool WillNotDraw()
        {
            return base.WillNotDraw();
        }

        protected override bool AwakenScrollBars()
        {
            return base.AwakenScrollBars();
        }

        protected override bool AwakenScrollBars(int startDelay)
        {
            return base.AwakenScrollBars(startDelay);
        }

        protected override bool AwakenScrollBars(int startDelay, bool invalidate)
        {
            return base.AwakenScrollBars(startDelay, invalidate);
        }

        protected override Java.Lang.Object Clone()
        {
            return base.Clone();
        }

        protected override int ComputeHorizontalScrollExtent()
        {
            return base.ComputeHorizontalScrollExtent();
        }

        protected override int ComputeHorizontalScrollOffset()
        {
            return base.ComputeHorizontalScrollOffset();
        }

        protected override int ComputeHorizontalScrollRange()
        {
            return base.ComputeHorizontalScrollRange();
        }

        protected override int ComputeVerticalScrollExtent()
        {
            return base.ComputeVerticalScrollExtent();
        }

        protected override int ComputeVerticalScrollOffset()
        {
            return base.ComputeVerticalScrollOffset();
        }

        protected override int ComputeVerticalScrollRange()
        {
            return base.ComputeVerticalScrollRange();
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            base.DispatchDraw(canvas);
        }

        protected override bool DispatchGenericFocusedEvent(MotionEvent e)
        {
            return base.DispatchGenericFocusedEvent(e);
        }

        protected override bool DispatchGenericPointerEvent(MotionEvent e)
        {
            return base.DispatchGenericPointerEvent(e);
        }

        protected override bool DispatchHoverEvent(MotionEvent e)
        {
            return base.DispatchHoverEvent(e);
        }

        protected override void DispatchRestoreInstanceState(SparseArray container)
        {
            base.DispatchRestoreInstanceState(container);
        }

        protected override void DispatchSaveInstanceState(SparseArray container)
        {
            base.DispatchSaveInstanceState(container);
        }

        protected override void DispatchSetActivated(bool activated)
        {
            base.DispatchSetActivated(activated);
        }

        protected override void DispatchSetPressed(bool pressed)
        {
            base.DispatchSetPressed(pressed);
        }

        protected override void DispatchSetSelected(bool selected)
        {
            base.DispatchSetSelected(selected);
        }

        protected override void DispatchVisibilityChanged(View changedView, [GeneratedEnum] ViewStates visibility)
        {
            base.DispatchVisibilityChanged(changedView, visibility);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void DrawableStateChanged()
        {
            base.DrawableStateChanged();
        }

        protected override bool FitSystemWindows(Rect insets)
        {
            return base.FitSystemWindows(insets);
        }

        protected override IOnKeyboardActionListener GetOnKeyboardActionListener()
        {
            return base.GetOnKeyboardActionListener();
        }

        protected override void InitializeFadingEdge(TypedArray a)
        {
            base.InitializeFadingEdge(a);
        }

        protected override void InitializeScrollbars(TypedArray a)
        {
            base.InitializeScrollbars(a);
        }

        protected override void JavaFinalize()
        {
            base.JavaFinalize();
        }

        protected override void OnAnimationEnd()
        {
            base.OnAnimationEnd();
        }

        protected override void OnAnimationStart()
        {
            base.OnAnimationStart();
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
        }

        protected override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
        }

        protected override void OnCreateContextMenu(IContextMenu menu)
        {
            base.OnCreateContextMenu(menu);
        }

        protected override int[] OnCreateDrawableState(int extraSpace)
        {
            return base.OnCreateDrawableState(extraSpace);
        }

       

        protected override void OnDisplayHint([IntDef(Type = "", Fields = new[] { "", "", "" })] int hint)
        {
            base.OnDisplayHint(hint);
        }

       
        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();
        }

        protected override void OnFocusChanged(bool gainFocus, [GeneratedEnum] FocusSearchDirection direction, Rect previouslyFocusedRect)
        {
            base.OnFocusChanged(gainFocus, direction, previouslyFocusedRect);
        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);
        }

        protected override bool OnLongPress(Keyboard.Key popupKey)
        {
            return base.OnLongPress(popupKey);
        }

       

        protected override void OnOverScrolled(int scrollX, int scrollY, bool clampedX, bool clampedY)
        {
            base.OnOverScrolled(scrollX, scrollY, clampedX, clampedY);
        }

        protected override void OnRestoreInstanceState(IParcelable state)
        {
            base.OnRestoreInstanceState(state);
        }

        protected override IParcelable OnSaveInstanceState()
        {
            return base.OnSaveInstanceState();
        }

        protected override void OnScrollChanged(int l, int t, int oldl, int oldt)
        {
            base.OnScrollChanged(l, t, oldl, oldt);
        }

        protected override bool OnSetAlpha(int alpha)
        {
            return base.OnSetAlpha(alpha);
        }

      

        protected override void OnVisibilityChanged(View changedView, [GeneratedEnum] ViewStates visibility)
        {
            base.OnVisibilityChanged(changedView, visibility);
        }

        protected override void OnWindowVisibilityChanged([GeneratedEnum] ViewStates visibility)
        {
            base.OnWindowVisibilityChanged(visibility);
        }

        protected override bool OverScrollBy(int deltaX, int deltaY, int scrollX, int scrollY, int scrollRangeX, int scrollRangeY, int maxOverScrollX, int maxOverScrollY, bool isTouchEvent)
        {
            return base.OverScrollBy(deltaX, deltaY, scrollX, scrollY, scrollRangeX, scrollRangeY, maxOverScrollX, maxOverScrollY, isTouchEvent);
        }

        protected override void SwipeDown()
        {
            base.SwipeDown();
        }

        protected override void SwipeLeft()
        {
            base.SwipeLeft();
        }

        protected override void SwipeRight()
        {
            base.SwipeRight();
        }

        protected override void SwipeUp()
        {
            base.SwipeUp();
        }

        protected override bool VerifyDrawable(Drawable who)
        {
            return base.VerifyDrawable(who);
        }
        

    }
}