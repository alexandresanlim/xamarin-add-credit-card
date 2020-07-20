using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinUI.AddCreditCard.Extentions
{
    public class ViewFlipper : ContentView
    {

        /// <summary>
        /// BindableProperty for <c>FrontView</c>
        /// </summary>
        public static readonly BindableProperty FrontViewProperty =
            BindableProperty.Create<ViewFlipper, View>(
                p => p.FrontView,
                default(View),
                propertyChanged: FrontViewChanged);
        /// <summary>
        /// BindableProperty for <c>BackView</c>
        /// </summary>
        public static readonly BindableProperty BackViewProperty =
            BindableProperty.Create<ViewFlipper, View>(
                p => p.BackView,
                default(View),
                propertyChanged: BackViewChanged);
        /// <summary>
        /// BindableProperty for <c>FlipOnTap</c>
        /// </summary>
        public static readonly BindableProperty FlipOnTapProperty =
            BindableProperty.Create<ViewFlipper, bool>(
                p => p.FlipOnTap,
                true);
        /// <summary>
        /// BindableProperty for <c>FlipState</c>
        /// </summary>
        public static readonly BindableProperty FlipStateProperty =
            BindableProperty.Create<ViewFlipper, FlipState>(
                p => p.FlipState,
                FlipState.Front,
                BindingMode.TwoWay,
                propertyChanged: FlipStateChanged);
        /// <summary>
        /// BindableProperty for <c>RotationDirection</c>
        /// </summary>
        public static readonly BindableProperty RotationDirectionProperty =
            BindableProperty.Create<ViewFlipper, RotationDirection>(
                p => p.RotationDirection,
                RotationDirection.Horizontal);
        /// <summary>
        /// BindableProperty for <c>AnimationDuration</c>
        /// </summary>
        public static readonly BindableProperty AnimationDurationProperty =
            BindableProperty.Create<ViewFlipper, int>(
                p => p.AnimationDuration,
                250);
        /// <summary>
        /// Gets/Sets the front view
        /// </summary>
        public View FrontView
        {
            get { return (View)this.GetValue(FrontViewProperty); }
            set { this.SetValue(FrontViewProperty, value); }
        }
        /// <summary>
        /// Gets/Sets the back view
        /// </summary>
        public View BackView
        {
            get { return (View)this.GetValue(BackViewProperty); }
            set { this.SetValue(BackViewProperty, value); }
        }
        /// <summary>
        /// Gets/Sets if a flip will be perfomed when tapping anywhere inside the <c>ViewFlipper</c>
        /// </summary>
        public bool FlipOnTap
        {
            get { return (bool)this.GetValue(FlipOnTapProperty); }
            set { this.SetValue(FlipOnTapProperty, value); }
        }
        /// <summary>
        /// Gets/Sets the current state of the <c>ViewFlipper</c>. This toggles the animation when changed
        /// </summary>
        public FlipState FlipState
        {
            get { return (FlipState)this.GetValue(FlipStateProperty); }
            set { this.SetValue(FlipStateProperty, value); }
        }
        /// <summary>
        /// Gets/Sets the duration of the flip animation
        /// </summary>
        public int AnimationDuration
        {
            get { return (int)this.GetValue(AnimationDurationProperty); }
            set { this.SetValue(AnimationDurationProperty, value); }
        }
        /// <summary>
        /// Gets/Sets if the flip will be in horizontal or vertical direction
        /// </summary>
        public RotationDirection RotationDirection
        {
            get { return (RotationDirection)this.GetValue(RotationDirectionProperty); }
            set { this.SetValue(RotationDirectionProperty, value); }
        }
        /// <summary>
        /// Creates a new instance of <c>ViewFlipper</c>
        /// </summary>
        public ViewFlipper()
        {
            this.GestureRecognizers.Add(
                new TapGestureRecognizer
                {
                    Command = new Command(this.OnTapped)
                });
        }
        /// <summary>
        /// Performs the flip
        /// </summary>
        private async void Flip()
        {
            var animationDuration = (uint)Math.Round((double)this.AnimationDuration / 2);

            if (this.FlipState == FlipState.Front)
            {
                // Perform half of the flip
                if (this.RotationDirection == RotationDirection.Horizontal)
                    await this.RotateYTo(90, animationDuration);
                else
                    await this.RotateXTo(90, animationDuration);

                // Change the visible content
                this.Content = this.FrontView;

                // Perform second half of the flip
                if (this.RotationDirection == RotationDirection.Horizontal)
                    await this.RotateYTo(0, animationDuration);
                else
                    await this.RotateXTo(0, animationDuration);
            }
            else
            {
                // Perform half of the flip
                if (this.RotationDirection == RotationDirection.Horizontal)
                    await this.RotateYTo(90, animationDuration);
                else
                    await this.RotateXTo(90, animationDuration);

                // Change the visible content
                this.Content = this.BackView;

                // Perform second half of the flip
                if (this.RotationDirection == RotationDirection.Horizontal)
                    await this.RotateYTo(180, animationDuration);
                else
                    await this.RotateXTo(180, animationDuration);
            }
        }
        /// <summary>
        /// Sets the rotation on the back view
        /// </summary>
        private void SetBackviewRotation()
        {
            if (this.RotationDirection == RotationDirection.Horizontal)
            {
                this.BackView.RotationX = 0;
                this.BackView.RotationY = 180;
            }
            else
            {
                this.BackView.RotationY = 0;
                this.BackView.RotationX = 180;
            }
        }
        /// <summary>
        /// When the <c>ViewFlipper</c> gets tapped
        /// </summary>
        private void OnTapped()
        {
            if (!this.FlipOnTap) return;

            this.FlipState = this.FlipState == FlipState.Front ?
                FlipState.Back :
                FlipState.Front;
        }
        /// <summary>
        /// When the <c>FlipState</c> changed
        /// </summary>
        /// <param name="obj">The <c>ViewFlipper</c></param>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        private static void FlipStateChanged(BindableObject obj, FlipState oldValue, FlipState newValue)
        {
            ViewFlipper flipper = obj as ViewFlipper;
            if (flipper == null) return;

            flipper.Flip();
        }
        /// <summary>
        /// When the <c>FrontView</c> changed
        /// </summary>
        /// <param name="obj">The <c>ViewFlipper</c></param>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        private static void FrontViewChanged(BindableObject obj, View oldValue, View newValue)
        {
            ViewFlipper flipper = obj as ViewFlipper;
            if (flipper == null) return;

            if (oldValue == null)
                flipper.Content = newValue;
        }
        /// <summary>
        /// When the <c>BackView</c> changed
        /// </summary>
        /// <param name="obj">The <c>ViewFlipper</c></param>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        private static void BackViewChanged(BindableObject obj, View oldValue, View newValue)
        {
            ViewFlipper flipper = obj as ViewFlipper;
            if (flipper == null || newValue == null) return;

            flipper.SetBackviewRotation();

        }
        /// <summary>
        /// When the <c>RotationDirection</c> changed
        /// </summary>
        /// <param name="obj">The <c>ViewFlipper</c></param>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        private static void RotationDirectionChanged(BindableObject obj, RotationDirection oldValue, RotationDirection newValue)
        {
            ViewFlipper flipper = obj as ViewFlipper;
            if (flipper == null || flipper.BackView == null) return;

            flipper.SetBackviewRotation();
        }

    }
    /// <summary>
    /// State of the <c>ViewFlipper</c>
    /// </summary>
    public enum FlipState
    {
        /// <summary>
        /// The front view is currently visible
        /// </summary>
        Front,
        /// <summary>
        /// The back view is currently visible
        /// </summary>
        Back
    }
    /// <summary>
    /// The direction of the flip animation
    /// </summary>
    public enum RotationDirection
    {
        /// <summary>
        /// Flip horizontal around the Y axis
        /// </summary>
        Horizontal,
        /// <summary>
        /// Flip vertical around the X axis
        /// </summary>
        Vertical
    }
}
