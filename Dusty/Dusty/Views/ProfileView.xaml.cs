using Acr.UserDialogs;
using Dusty.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Dusty.Views
{
    public partial class ProfileView : ViewBase<ProfileViewModel>
    {
        public override bool WrapWithNavigationPage => true;

        public ProfileView()
        {
            InitializeComponent();

            //NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
