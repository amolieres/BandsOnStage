using Bands.Models;
using Bands.Services.BandsintownServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace Bands.ViewModels
{
    public class AroundPageViewModel : Bands.Mvvm.ViewModelBase
    {

        private ObservableCollection<BitEvent> _EventList;
        public ObservableCollection<BitEvent> EventList { get { return _EventList; } private set { Set(ref _EventList, value); } }

        public AroundPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            { 
                return;
            }
            SearchNearbyEvents("Bordeaux,FR");
        }

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (state.Any())
            {
                // use cache value(s)
                //if (state.ContainsKey(nameof(EventList))) EventList = (BitEvent)state[nameof(EventList)]?.ToString();
                // clear any cache
                state.Clear();
            }
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            if (suspending)
            {
                // persist into cache
                state[nameof(EventList)] = EventList;
            }
            return base.OnNavigatedFromAsync(state, suspending);
        }


        private async void SearchNearbyEvents(string location)
        {
            try
            {
                //Searching events for the band with Bandsintown services
                BitEventsService search = new BitEventsService();
                _EventList = new ObservableCollection<BitEvent>(await search.GetEventsNearbyAsync(location));
                this.RaisePropertyChanged(nameof(EventList));

                //Best way is the folowing loop... But sadly don't work 
                /*
                List<BitEvent> elems = await search.GetEventsForArtistAsync(_Artist);
                foreach (BitEvent eventTemp in elems)
                {
                    _EventList.Add(eventTemp);
                }*/


            }
            catch (Exception)
            {
                //Catching bad argument input
                MessageDialog msgDialog = new MessageDialog("\"" + location + "\" is not valid , please retry", "404 : Location not valid :'(");
                await msgDialog.ShowAsync();

            }

        }

        public override void OnNavigatingFrom(NavigatingEventArgs args)
        {
            base.OnNavigatingFrom(args);
        }

        public void GotoEventPage(object sender, ItemClickEventArgs e)
        {
            BitEvent itemSelected = ((BitEvent)e.ClickedItem);

            if (itemSelected != null)
            {
                this.NavigationService.Navigate(typeof(Views.EventPage), itemSelected);
            }

        }
    }
}

