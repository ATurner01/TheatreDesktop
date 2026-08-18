using System.Windows.Input;
using TheatreDesktop.Services;

namespace TheatreDesktop.ViewModel
{
    public class HomePageViewModel : PageViewModel
    {
        protected readonly IDialogService _dialogService;
        public string? DataPath { get; private set; }
        public ICommand? MoviesCommand { get; private set; }
        public ICommand? AccountCommand { get; private set; }

        public HomePageViewModel(INavigationService navigationService, IApplicationService applicationService,
                                IDialogService dialogService, string? dataPath = null)
                : base(navigationService, applicationService)
        {
            DataPath = dataPath;
            _dialogService = dialogService;
            base.DisplayName = "Homepage";
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            CloseCommand = new RelayCommand(Exit);
            MoviesCommand = null;
            AccountCommand = null;
        }

        private void Exit()
        {
            bool confirmed = _dialogService.Confirm(
                "Are you sure you want to exit?",
                "Confirm Exit");

            if (confirmed)
            {
                ApplicationService.Shutdown();
            }
        }

        protected override void OnDispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DataPath = String.Empty;
                    MoviesCommand = null;
                    AccountCommand = null;
                }
                // Also need to make sure DB connections are closed here once implemented
                base.OnDispose(disposing); // Call the base class OnDispose *after* this class so that the disposed flag is set correctly
            }
        }
    }
}
