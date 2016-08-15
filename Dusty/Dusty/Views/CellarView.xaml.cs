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
    public partial class CellarView : ViewBase<CellarViewModel>
    {
        public override bool WrapWithNavigationPage => true;

        public CellarView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
