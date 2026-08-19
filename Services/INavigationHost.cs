using System.Windows.Controls;

namespace TheatreDesktop.Services
{
    public interface INavigationHost
    {
        void Navigate(Page page);
        void GoBack();
        bool CanGoBack { get; }
    }
}
