using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TheatreDesktop.Services;

namespace TheatreDesktop.ViewModel
{
    public class SettingsViewModel : PageViewModel
    {
        public ICommand BackCommand { get; private set; }
        public SettingsViewModel(INavigationService navigationService, IApplicationService applicationService)
            : base(navigationService, applicationService)
        {
            DisplayName = "Settings";
            BackCommand = new RelayCommand(NavigationServiceHelper.GoBack);
        }
    }
}
