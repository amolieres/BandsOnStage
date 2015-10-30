using Bands.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;

namespace Bands.Views
{
    public sealed partial class BandPage : Page
    {
        public BandPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public BandPageViewModel ViewModel => DataContext as BandPageViewModel;
    }
}

