using TheatreDesktop.Services;

namespace TheatreDesktop.ViewModel
{
    public class HomePageViewModel : PageViewModel
    {
        private readonly IDialogService _dialogService;
        private readonly IApplicationService _applicationService;
        public string? DataPath { get; private set; }

        public HomePageViewModel(IApplicationService applicationService, IDialogService dialogService, string? dataPath = null)
        {
            DataPath = dataPath;
            _applicationService = applicationService;
            _dialogService = dialogService;
            base.DisplayName = "Homepage";
            CloseCommand = new RelayCommand(Exit);
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
    }
}
