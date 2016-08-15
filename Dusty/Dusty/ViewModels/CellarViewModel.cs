using PropertyChanged;
using Dusty.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Dusty.Models;
using System.Collections.ObjectModel;
using RestSharp.Portable;
using Acr.UserDialogs;

namespace Dusty.ViewModels
{
    [ImplementPropertyChanged]
    public class CellarViewModel : ViewModelBase
    {
        public bool IsRefreshing { get; set; }
        public ICommand RefreshCommand { get; }
        public IList<CellarDto> Entries { get; private set; }

        private INavigationService _navigation;

        public CellarViewModel(INavigationService navigation)
        {
            _navigation = navigation;

            Entries = new ObservableCollection<CellarDto>();
            RefreshCommand = new Command(async () => await DoRefreshCommand());
        }

        private async Task DoRefreshCommand()
        {
            var req = new RestRequest("cellar", Method.GET);
            var res = await App.Client.Execute<List<CellarDto>>(req);

            if (res.StatusCode != System.Net.HttpStatusCode.OK)
                await UserDialogs.Instance.AlertAsync("Error refreshing cellar.");

            IsRefreshing = false;
            Entries = new ObservableCollection<CellarDto>(res.Data);
        }
    }
}