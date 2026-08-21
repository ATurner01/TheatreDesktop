using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using TheatreDesktop.ViewModel;
using TheatreDesktop.Views;

namespace TheatreDesktop.Services
{
    /// <summary>
    /// A helper class that implements the INavigationService interface and provides navigation functionality for the application.
    /// </summary>
    public class NavigationServiceHelper : INavigationService
    {
        private readonly INavigationHost _navigationHost;
        private readonly IServiceProvider _serviceProvider;

        // A dictionary that maps ViewModel types to their corresponding Page types.
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

        /// <summary>
        /// Navigates to the page associated with the specified ViewModel type.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the ViewModel to navigate to.</typeparam>
        public void NavigateTo<TViewModel>()
        {
            var viewModel = _serviceProvider.GetService<TViewModel>();
            var page = ResolvePage<TViewModel>();
            page.DataContext = viewModel;
            _navigationHost.Navigate(page);
        }

        /// <summary>
        /// Navigates to the page associated with the specified ViewModel type, passing a parameter to the ViewModel's constructor.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the ViewModel to navigate to.</typeparam>
        /// <typeparam name="TParameter">The type of the parameter to pass to the ViewModel's constructor.</typeparam>
        /// <param name="parameter">The parameter to pass to the ViewModel's constructor.</param>
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

        /// <summary>
        /// Navigates back to the previous page in the navigation stack.
        /// </summary>
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
