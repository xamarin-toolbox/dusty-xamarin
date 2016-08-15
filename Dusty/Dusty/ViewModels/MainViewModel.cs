using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusty.ViewModels
{
    public class MainViewModel : TabViewModelBase
    {
        public MainViewModel(CellarViewModel cellar, FeedViewModel feed)
        {
            Tabs = new List<IViewModel> { cellar, feed };
        }
    }
}
