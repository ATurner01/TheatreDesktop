namespace TheatreDesktop.ViewModel
{
    public class HomePageViewModel : PageViewModel
    {
        private string? DataPath { get; set; }

        public HomePageViewModel() : this(null)
        {
        }
        public HomePageViewModel(string? dataPath)
        {
            DataPath = dataPath;
            base.DisplayName = "Homepage";
            this.CloseCommand = new CommandViewModel("Close", new RelayCommand(param => OnRequestClose()));
        }

        public override void OnRequestClose()
        {
            base.OnRequestClose();
        }
    }
}
