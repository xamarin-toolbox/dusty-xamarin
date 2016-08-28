using Dusty.Controls;
using Dusty.iOS.Renderers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MDButton), typeof(MDButtonRenderer))]
namespace Dusty.iOS.Renderers
{
    public class MDButtonRenderer : ViewRenderer<MDButton, MaterialControls.MDButton>
    {
        public IButtonController Controller => Element as IButtonController;
        //public MDButton MDControl => Element as MDButton;
        //public MaterialControls.MDButton Native => NativeView as MaterialControls.MDButton;

        protected override void OnElementChanged(ElementChangedEventArgs<MDButton> e)
        {
            //base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            var native = new MaterialControls.MDButton();
            native.Type = 2;
            native.MdButtonType = MaterialControls.MDButtonType.FloatingAction;
            native.TouchUpInside += OnNativeTouchUpInside;
            native.BackgroundColor = UIColor.FromRGB(0x45, 0x5A, 0x64);
            native.RippleColor = UIColor.FromRGB(0x60, 0x7D, 0x8B);

            SetNativeControl(native);

            UpdateText();
            //UpdateBorder();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == MDButton.TextProperty.PropertyName)
                UpdateText();
            //else if (e.PropertyName == Button.BorderWidthProperty.PropertyName || e.PropertyName == Button.BorderRadiusProperty.PropertyName || e.PropertyName == Button.BorderColorProperty.PropertyName)
            //    UpdateBorder();
        }

        //void UpdateBorder()
        //{
        //    var uiButton = Control;
        //    var button = Element;

        //    if (button.BorderColor != Color.Default)
        //        uiButton.Layer.BorderColor = button.BorderColor.ToCGColor();

        //    uiButton.Layer.BorderWidth = (float)button.BorderWidth;
        //    uiButton.Layer.CornerRadius = button.BorderRadius;
        //}

        void UpdateText()
        {
            var newText = Element.Text;

            if (Control.Title(UIControlState.Normal) != newText)
            {
                Control.SetTitle(Element.Text, UIControlState.Normal);
            }
        }

        private void OnNativeTouchUpInside(object sender, EventArgs e)
            => Controller?.SendClicked();
    }
}