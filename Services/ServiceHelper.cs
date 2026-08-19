using Microsoft.Extensions.DependencyInjection;
using TheatreDesktop.ViewModel;
using TheatreDesktop.Views;

namespace TheatreDesktop.Services
{
    public class ServiceHelper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Services
            services.AddSingleton<IApplicationService, ApplicationService>();
            services.AddSingleton<IDialogService, DialogService>();
            // ViewModels
            services.AddTransient<HomePageViewModel>();
            services.AddTransient<MovieViewModel>();
            services.AddTransient<AccountViewModel>();
            // Views
            services.AddTransient<HomePage>();
            services.AddTransient<Movies>();
            services.AddTransient<Account>();
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
        }
    }
}
