using System.Windows;
using System.Windows.Controls;

namespace TheatreDesktop.Services
{
    public interface INavigationService
    {
        public void NavigateTo<TViewModel>();
    }
}
