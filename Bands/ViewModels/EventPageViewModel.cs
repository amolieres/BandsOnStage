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
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;


namespace Bands.ViewModels
{
    public class EventPageViewModel : Bands.Mvvm.ViewModelBase
    {

        private BitEvent _Event = null;
        public BitEvent eventData { get { return _Event; } set { Set(ref _Event, value); } }


        public EventPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                return;
            }
            /*
            Maps EventLocationMap = new Map();
            MyMap.Center = new GeoCoordinate(47.6097, -122.3331);
            ContentPanel.Children.Add(MyMap);*/

        }

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (state.Any())
            {
                // use cache value(s)
                if (state.ContainsKey(nameof(eventData))) _Event = (BitEvent)state[nameof(eventData)];
                // clear any cache
                state.Clear();
            }
            else
            {
                // use navigation parameter
                _Event = (BitEvent)parameter;
            }
        }
        /*
        private void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            EventLocationMap.Center =
                new Geopoint(new BasicGeoposition()
                {
                    //Geopoint for Seattle 
                    Latitude = 47.604,
                    Longitude = -122.329
                });
            EventLocationMap.ZoomLevel = 12;

        }*/

        public override Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            if (suspending)
            {
                // persist into cache
                state[nameof(eventData)] = eventData;
            }
            return base.OnNavigatedFromAsync(state, suspending);
        }

        public override void OnNavigatingFrom(NavigatingEventArgs args)
        {
            args.Cancel = false;
        }

    }
}

