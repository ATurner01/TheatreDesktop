using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using TheatreDesktop.ViewModel;
using TheatreDesktop.Views;

namespace TheatreDesktop.Services
{
    public class NavigationServiceHelper : INavigationService
    {
        private readonly INavigationHost _navigationHost;
        private readonly IServiceProvider _serviceProvider;

        private readonly Dictionary<Type, Type> _viewMappings = new()
        {
            { typeof(HomePageViewModel), typeof(HomePage) }
        };

        public NavigationServiceHelper(INavigationHost navigationHost, IServiceProvider serviceProvider)
        {
            _navigationHost = navigationHost;
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo<TViewModel>()
        {
            var page = ResolvePage<TViewModel>();
            _navigationHost.Navigate(page);
        }

        private Page ResolvePage<TViewModel>()
        {
            var viewModelType = typeof(TViewModel);

            if (!_viewMappings.TryGetValue(viewModelType, out var pageType))
            {
                throw new InvalidOperationException(
                    $"No page is registered for ViewModel '{viewModelType.Name}'.");
            }

            return (Page)_serviceProvider.GetRequiredService(pageType);
        }
    }
}
