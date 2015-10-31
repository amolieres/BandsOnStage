using Bands.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;

namespace Bands.Views
{
    public sealed partial class EventPage : Page
    {
        public EventPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
            
        }

        // strongly-typed view models enable x:bind
        public EventPageViewModel ViewModel => DataContext as EventPageViewModel;
    }
}

