using Bands.Models;
using Bands.Services.BandsintownServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Bands.ViewModels
{
    public class SearchPageViewModel : Bands.Mvvm.ViewModelBase 
    {
        public SearchPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime data
                Value = "Designtime value";
                return;
            }
        }

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (state.Any())
            {
                // use cache value(s)
                if (state.ContainsKey(nameof(Value))) Value = state[nameof(Value)]?.ToString();
                // clear any cache
                state.Clear();
            }
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            if (suspending)
            {
                // persist into cache
                state[nameof(Value)] = Value;
            }
            return base.OnNavigatedFromAsync(state, suspending);
        }

        public override void OnNavigatingFrom(NavigatingEventArgs args)
        {
            base.OnNavigatingFrom(args);
        }

        private string _Value = string.Empty;
        public string Value { get { return _Value; } set { Set(ref _Value, value); } }

        
        public async void SearchForBand()
        {
            try
            {

                //Searching for a band with Bandsintown services
                BitArtistsService search = new BitArtistsService();
                BitArtist artist = await search.GetArtistAsync(this.Value);

                if (artist != null) {
                    this.NavigationService.Navigate(typeof(Views.BandPage), artist);
                }

            }

            catch (ArgumentException)
            {
                //Catching bad argument input
                MessageDialog msgDialog = new MessageDialog("\"" +this.Value + "\" is not valid , please retry", "404 : Band not found:'(");
                await msgDialog.ShowAsync();
            }

            catch (Exception)
            {
                //Catching no service or notfound band
                MessageDialog msgDialog = new MessageDialog("No bands found for \""+ this.Value + "\" please retry... ", "404 : Band not found :'(");
                await msgDialog.ShowAsync();
            }

        }
    }
}

