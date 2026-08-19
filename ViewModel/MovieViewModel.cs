using System.Windows.Input;
using TheatreDesktop.Services;

namespace TheatreDesktop.ViewModel
{
    public class MovieViewModel : PageViewModel
    {
        public ICommand HomeCommand { get; private set; }

        public MovieViewModel(INavigationService navigationService, IApplicationService applicationService) 
            : base(navigationService, applicationService)
        {
            DisplayName = "Movies";
            HomeCommand = new RelayCommand(NavigationServiceHelper.NavigateTo<HomePageViewModel>);
        }
    }
}
