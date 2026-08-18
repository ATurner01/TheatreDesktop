using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TheatreDesktop.Services;
using TheatreDesktop.ViewModel;
using TheatreDesktop.Views;

namespace TheatreDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            // Services
            services.AddSingleton<IApplicationService, ApplicationService>();
            services.AddSingleton<IDialogService, DialogService>();

            // ViewModels
            services.AddTransient<HomePageViewModel>();

            // Views
            services.AddTransient<HomePage>();

            // Main window
            services.AddSingleton<MainWindow>();

            // Navigation
            services.AddSingleton<INavigationHost>(provider =>
                provider.GetRequiredService<MainWindow>());

            services.AddSingleton<INavigationService>(provider =>
            {
                var navigationHost = provider.GetRequiredService<INavigationHost>();

                return new NavigationServiceHelper(
                    navigationHost,
                    provider);
            });

            var _serviceProvider = services.BuildServiceProvider();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            var navigationService = _serviceProvider.GetRequiredService<INavigationService>();

            navigationService.NavigateTo<HomePageViewModel>();

            mainWindow.Show();
        }
    }

}
