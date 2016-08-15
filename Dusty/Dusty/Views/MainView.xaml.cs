using Acr.UserDialogs;
using Dusty.Services;
using Dusty.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Dusty.Views
{
    public partial class MainView : TabViewBase<MainViewModel>
    {
        public MainView(IViewService viewService)
            : base(viewService)
        {
            InitializeComponent();
        }
    }
}
