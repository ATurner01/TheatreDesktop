using System.Windows.Input;

namespace TheatreDesktop.ViewModel
{
    /// <summary>
    /// Represents a command in the MVVM pattern. It encapsulates an ICommand and provides a display name for the command.
    /// </summary>
    public class CommandViewModel : ViewModelBase
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
