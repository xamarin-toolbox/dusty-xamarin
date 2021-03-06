using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusty
{
    public interface IViewModelWithTabs : IViewModel
    {
        event EventHandler TabsChanged;
        IList<IViewModel> Tabs { get; }
    }
}
