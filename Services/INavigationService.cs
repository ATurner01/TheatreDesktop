using System.Windows;

namespace TheatreDesktop.Services
{
    public interface INavigationService
    {
        public void NavigateTo(string? pageKey);
    }
}
