using System.Windows.Input;

namespace TheatreDesktop.Services
{
    /// <summary>
    /// A class for creating a binding between WPF ICommand instances and C# methods. This allows us to use regular C# methods as commands in WPF controls.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        /// <summary>
        /// Create a new instance of the RelayCommand class for executing the supplied Action. Takes an optional canExecute argument to determine if the Action should be run.
        /// </summary>
        /// <param name="execute">The Action that is to be executed.</param>
        /// <param name="canExecute">An optional function delegate that determines if the Action supplied can be executed. Null by default.</param>
        /// <exception cref="ArgumentNullException">Thrown in the event that null is provided as the value for the execute parameter.</exception>
        public RelayCommand(
            Action execute,
            Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Invokes the canExecute delegate supplied on object creation, if defined. Returns true if the canExecute property is null.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>A conditional representing if the Action can be executed.</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }

        /// <summary>
        /// Executes the Action provided by the execute property.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            _execute();
        }

        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Alerts that the canExecute property has been changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// A modified version of RelayCommand that accepts a Generic Type parameter for passing arguments along with the specified Action.
    /// </summary>
    /// <typeparam name="T">The Type parameter which refers to the argument type of the Action.</typeparam>
    /// <seealso cref="RelayCommand"/>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool>? _canExecute;

        public RelayCommand(
            Action<T> execute,
            Func<T, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is T tParam)
            {
                return _canExecute?.Invoke(tParam) ?? true;
            }
            return false;
        }
        public void Execute(object? parameter)
        {
            if (parameter is T tParam)
            {
                _execute(tParam);
            }
        }

        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
