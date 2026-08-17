using System.ComponentModel;

namespace TheatreDesktop.ViewModel
{
    /// <summary>
    /// Abstract class to represent a ViewModel in the MVVM pattern. Implements INotifyPropertyChanged and IDisposable interfaces.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        protected string DisplayName { get; set; }
        protected bool ThrowOnInvalidPropertyName { get; set; }
        private bool disposed = false;
        public event PropertyChangedEventHandler? PropertyChanged;

        public ViewModelBase()
        {
            DisplayName = String.Empty;
            ThrowOnInvalidPropertyName = false;
        }

        public void Dispose()
        {
            OnDispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the ViewModel and releases any resources. If disposing is true, it also releases managed resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void OnDispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    PropertyChanged = null;
                }

                this.disposed = true;
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Verifies that the specified property name exists in the ViewModel. If the property name is invalid, it either throws an exception or triggers a debug failure based on the ThrowOnInvalidPropertyName flag.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <exception cref="Exception"></exception>
        public void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;
                if (ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    System.Diagnostics.Debug.Fail(msg);
            }
        }
    }
}
