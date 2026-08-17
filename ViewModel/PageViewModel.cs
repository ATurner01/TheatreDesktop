namespace TheatreDesktop.ViewModel
{
    /// <summary>
    /// Abstract class to represent a Page ViewModel in the MVVM pattern. Inherits from ViewModelBase and provides functionality for closing the page.
    /// </summary>
    public abstract class PageViewModel : ViewModelBase
    {
        public CommandViewModel? CloseCommand { get; set; }
        public event EventHandler? RequestClose;

        public PageViewModel()
        {
        }
        public virtual void OnRequestClose()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
