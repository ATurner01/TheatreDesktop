using System.Windows.Input;

namespace TheatreDesktop.ViewModel
{
    class CommandViewModel : ViewModelBase
    {
        public ICommand Command { get; private set; }
        public CommandViewModel(string displayName, ICommand command)
        {
            ArgumentNullException.ThrowIfNull(command);
            base.DisplayName = displayName;
            this.Command = command;
        }
    }
}
