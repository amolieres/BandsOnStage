using Bands.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Bands.Views
{
    public sealed partial class FavoritesPage : Page
    {
        public FavoritesPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public FavoritesPageViewModel ViewModel => this.DataContext as FavoritesPageViewModel;
    }
}
