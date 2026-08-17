using System.Windows;
using System.Windows.Navigation;

namespace TheatreDesktop.Services
{
    public class NavigationServiceHelper : INavigationService
    {
        private readonly DependencyObject _page;
        public NavigationServiceHelper(DependencyObject page)
        {
            _page = page;
        }

        public void NavigateTo(string? pageKey)
        {
            ArgumentNullException.ThrowIfNull(pageKey, nameof(pageKey));
            NavigationService nav = NavigationService.GetNavigationService(_page);
            nav.Navigate(new Uri(pageKey, UriKind.Relative));
        }
    }
}
