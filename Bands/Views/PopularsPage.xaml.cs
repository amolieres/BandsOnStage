using Bands.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Bands.Views
{
    public sealed partial class PopularsPage : Page
    {
        public PopularsPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public PopularsPageViewModel ViewModel => this.DataContext as PopularsPageViewModel;
    }
}
