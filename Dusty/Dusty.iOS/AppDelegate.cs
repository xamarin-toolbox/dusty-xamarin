using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using HockeyApp.iOS;
using Xamarin.Forms;

namespace Dusty.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication uiApp, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // Create app.
            var app = new App();

            // Start HockeyApp manager.
            InitializeHockeyApp();

            // Load our app.
            LoadApplication(app);

            // Styling.
            ApplyStyle();

            return base.FinishedLaunching(uiApp, options);
        }

        //private void ApplyStyle()
        //{
        //    //UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
        //    //UIApplication.SharedApplication.SetStatusBarHidden(false, false);

        //    UINavigationBar.Appearance.TintColor = UIColor.White;
        //    UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(0x37, 0x47, 0x4F);
        //    //UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White });
        //    //UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes() { ForegroundColor = UIColor.White };
        //    //UIBarButtonItem.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White }, UIControlState.Normal);
        //}

        private void ApplyStyle()
        {
            var tint = UIColor.FromRGB(0x37, 0x47, 0x4F);

            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BarTintColor = tint;
            //UIBarButtonItem.Appearance.SetTitleTextAttributes(new UITextAttributes { TextColor = UIColor.White }, UIControlState.Normal);

            UISearchBar.Appearance.TintColor = tint;
            //UIBarButtonItem.Appearance.TintColor = tint;

            UIView.Appearance.TintColor = tint;

            UITabBar.Appearance.BarTintColor = tint;
            UITabBar.Appearance.TintColor = UIColor.White;
        }

        private void InitializeHockeyApp()
        {
            if (String.IsNullOrWhiteSpace(App.Secrets.HockeyAppId))
                return;

            var hockeyManager = BITHockeyManager.SharedHockeyManager;

            hockeyManager.Configure(App.Secrets.HockeyAppId);
            hockeyManager.DebugLogEnabled = true;
            hockeyManager.StartManager();
        }
    }
}
