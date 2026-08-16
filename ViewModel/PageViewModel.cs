namespace TheatreDesktop.ViewModel
{
    /// <summary>
    /// Abstract class to represent a Page ViewModel in the MVVM pattern. Inherits from ViewModelBase and provides functionality for closing the page.
    /// </summary>
    abstract class PageViewModel : ViewModelBase
    {
        protected CommandViewModel? CloseCommand { get; set; }
        public event EventHandler? CloseRequested;

        public PageViewModel()
        {
            CloseCommand = new CommandViewModel("Close", new RelayCommand(param => this.OnRequestClose()));
        }
        public virtual void OnRequestClose()
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
