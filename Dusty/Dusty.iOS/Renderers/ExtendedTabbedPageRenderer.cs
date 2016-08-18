using Dusty.iOS.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(ExtendedTabbedPageRenderer))]
namespace Dusty.iOS.Renderers
{
    public class ExtendedTabbedPageRenderer : TabbedRenderer
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            foreach (var tab in TabBar.Items)
            {
                tab.Title = "";
                tab.ImageInsets = new UIKit.UIEdgeInsets(6, 0, -6, 0);
            }
        }
    }
}