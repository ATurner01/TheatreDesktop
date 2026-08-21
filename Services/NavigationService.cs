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
            { typeof(HomePageViewModel), typeof(HomePage) },
            { typeof(MovieViewModel), typeof(Movies) },
            { typeof(AccountViewModel), typeof(Account) },
            { typeof(SettingsViewModel), typeof(Settings) }
        };

        public NavigationServiceHelper(INavigationHost navigationHost, IServiceProvider serviceProvider)
        {
            _navigationHost = navigationHost;
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo<TViewModel>()
        {
            var viewModel = _serviceProvider.GetService<TViewModel>();
            var page = ResolvePage<TViewModel>();
            page.DataContext = viewModel;
            _navigationHost.Navigate(page);
        }

        public void NavigateTo<TViewModel, TParameter>(TParameter parameter)
        {
            ArgumentNullException.ThrowIfNull(parameter, nameof(parameter));
            var viewModel = ActivatorUtilities.CreateInstance<TViewModel>(
                _serviceProvider,
                parameter);

            var page = ResolvePage<TViewModel>();
            page.DataContext = viewModel;
            _navigationHost.Navigate(page);
        }

        public void GoBack()
        {
            _navigationHost.GoBack();
        }
        public bool CanGoBack => _navigationHost.CanGoBack;

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
