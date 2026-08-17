using System.Windows.Input;
using TheatreDesktop.Services;

namespace TheatreDesktop.ViewModel
{
    public class HomePageViewModel : PageViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IApplicationService _applicationService;
        private readonly INavigationService _navigationService;

        public string? DataPath { get; private set; }
        public ICommand? Navigate { get; private set; }

        public HomePageViewModel(IApplicationService applicationService, IDialogService dialogService, INavigationService navigationService, string? dataPath = null)
        {
            DataPath = dataPath;
            _applicationService = applicationService;
            _dialogService = dialogService;
            _navigationService = navigationService;
            base.DisplayName = "Homepage";
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            CloseCommand = new RelayCommand(Exit);
            Navigate = new RelayCommand<string>(NavigateTo);
        }

        private void Exit()
        {
            bool confirmed = _dialogService.Confirm(
                "Are you sure you want to exit?",
                "Confirm Exit");

            if (confirmed)
            {
                _applicationService.Shutdown();
            }
        }

        private void NavigateTo(string? pageKey)
        {
            _navigationService.NavigateTo(pageKey);
        }
    }
}
