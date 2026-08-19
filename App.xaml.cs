using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TheatreDesktop.Services;
using TheatreDesktop.ViewModel;

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
            ServiceHelper.RegisterServices(services);

            var _serviceProvider = services.BuildServiceProvider();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            var navigationService = _serviceProvider.GetRequiredService<INavigationService>();

            navigationService.NavigateTo<HomePageViewModel>();

            mainWindow.Show();
        }
    }

}
