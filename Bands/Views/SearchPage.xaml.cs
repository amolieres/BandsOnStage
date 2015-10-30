using Bands.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Bands.Views
{
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public SearchPageViewModel ViewModel => this.DataContext as SearchPageViewModel;
    }
}
