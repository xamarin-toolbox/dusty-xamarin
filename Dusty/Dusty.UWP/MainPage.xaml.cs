using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.HockeyApp;

namespace Dusty.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var app = new Dusty.App();

            if (!String.IsNullOrWhiteSpace(Dusty.App.Secrets.HockeyAppId))
                Microsoft.HockeyApp.HockeyClient.Current.Configure(Dusty.App.Secrets.HockeyAppId);

            LoadApplication(app);
        }
    }
}
