using Bands.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Bands.Views
{
    public sealed partial class AroundPage : Page
    {
        public AroundPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public AroundPageViewModel ViewModel => this.DataContext as AroundPageViewModel;
    }
}
