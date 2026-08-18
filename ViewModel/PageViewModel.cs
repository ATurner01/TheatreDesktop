using System.Windows.Input;
using TheatreDesktop.Services;

namespace TheatreDesktop.ViewModel
{
    /// <summary>
    /// Abstract class to represent a Page ViewModel in the MVVM pattern. Inherits from ViewModelBase and provides functionality for closing the page.
    /// </summary>
    public abstract class PageViewModel : ViewModelBase
    {
        public ICommand? CloseCommand { get; set; }
        protected static INavigationService NavigationServiceHelper { get; set; }
        protected static IApplicationService ApplicationService { get; set; }
        public PageViewModel(INavigationService navigationService, IApplicationService applicationService)
        {
            NavigationServiceHelper = navigationService;
            ApplicationService = applicationService;
        }
    }
}
