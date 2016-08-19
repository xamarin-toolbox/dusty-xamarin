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

            //NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.RefreshCommand.Execute(null);
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
