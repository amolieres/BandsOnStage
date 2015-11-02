using Bands.Models;
using Bands.Services.BandsintownServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Bands.ViewModels
{
    public class BandPageViewModel : Bands.Mvvm.ViewModelBase
    {


        private string _Name = "Default";
        private BitArtist _Artist = null;


        public string Name { get { return _Name; } set { Set(ref _Name, value); } }

        public BitArtist artist { get { return _Artist; } set { Set(ref _Artist, value); } }

        private ObservableCollection<BitEvent> _EventList;
        public  ObservableCollection<BitEvent> eventList { get { return _EventList; } private set { Set(ref _EventList, value); } }


        public BandPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime data
                this.Name = "Metallica";
                return;
            }
        }

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (state.Any())
            {
                // use cache value(s)
                if (state.ContainsKey(nameof(Name))) Name = state[nameof(Name)]?.ToString();
                // clear any cache
                state.Clear();
            }
            else
            {
                // use navigation parameter
                //Name = parameter?.ToString();

                _Artist = (BitArtist)parameter;
                SearchBandEvents();
            }
        }


        private async void SearchBandEvents()
        {
            try
            {
                //Searching events for the band with Bandsintown services
                BitEventsService search = new BitEventsService();
                _EventList = new ObservableCollection<BitEvent>(await search.GetEventsForArtistAsync(_Artist));
                this.RaisePropertyChanged("eventList");

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
                MessageDialog msgDialog = new MessageDialog("\"" + _Artist.Name + "\" is not valid , please retry", "404 : Band not found:'(");
                await msgDialog.ShowAsync();

            }

        }


        public void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            BitEvent itemSelected = ((BitEvent)e.ClickedItem);

            if (itemSelected != null)
            {
                this.NavigationService.Navigate(typeof(Views.EventPage), itemSelected);
            }

        }


        public override Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            if (suspending)
            {
                // persist into cache
                state[nameof(Name)] = Name;
            }
            return base.OnNavigatedFromAsync(state, suspending);
        }

        public override void OnNavigatingFrom(NavigatingEventArgs args)
        {
            args.Cancel = false;
        }

    }
}

