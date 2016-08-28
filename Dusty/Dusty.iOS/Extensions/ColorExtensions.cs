using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UIKit;
using Xamarin.Forms;

namespace System
{
    public static class ColorExtensions
    {
        public static UIColor ToUIColor(this Color color)
            => new UIColor((nfloat)color.R, (nfloat)color.G, (nfloat)color.B, (nfloat)color.A);
    }
}