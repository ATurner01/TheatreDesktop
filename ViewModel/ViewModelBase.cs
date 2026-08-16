using System.ComponentModel;


namespace TheatreDesktop.ViewModel
{
    internal abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        string DisplayName { get; set; }
        bool ThrowOnInvalidPropertyName { get; set; }
        private bool disposed = false;
        public event PropertyChangedEventHandler? PropertyChanged;

        public ViewModelBase(string  displayName)
        {
            DisplayName = displayName;
            ThrowOnInvalidPropertyName = false;
        }

        public ViewModelBase() : this(string.Empty)
        {
        }

        public void Dispose()
        {
            OnDispose(true);
            GC.SuppressFinalize(this);
        }

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
