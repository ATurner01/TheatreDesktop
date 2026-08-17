using System.Windows.Input;

namespace TheatreDesktop.ViewModel
{
    /// <summary>
    /// Abstract class to represent a Page ViewModel in the MVVM pattern. Inherits from ViewModelBase and provides functionality for closing the page.
    /// </summary>
    public abstract class PageViewModel : ViewModelBase
    {
        public ICommand? CloseCommand { get; set; }
        public PageViewModel()
        {
        }
    }
}
