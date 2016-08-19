using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Dusty.Controls;
using Dusty.Droid.Renderers;

[assembly: ExportRenderer(typeof(ListViewNoSelection), typeof(ListViewNoSelectionRenderer))]
namespace Dusty.Droid.Renderers
{
    public class ListViewNoSelectionRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            Control.SetSelector(Resource.Drawable.no_selector);
            Control.CacheColorHint = Xamarin.Forms.Color.Transparent.ToAndroid();
        }
    }
}