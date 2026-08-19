using System.Windows.Input;
using TheatreDesktop.Services;

namespace TheatreDesktop.ViewModel
{
    public class AccountViewModel : PageViewModel
    {
        public ICommand HomeCommand { get; private set; }

        public AccountViewModel(INavigationService navigationService, IApplicationService applicationService)
            : base(navigationService, applicationService)
        {
            DisplayName = "Account";
            HomeCommand = new RelayCommand(NavigationServiceHelper.NavigateTo<HomePageViewModel>);
        }
    }
}
