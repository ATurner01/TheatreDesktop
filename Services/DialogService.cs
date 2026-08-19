using System.Windows;

namespace TheatreDesktop.Services
{
    public class DialogService : IDialogService
    {
        public bool Confirm(string message, string title)
        {
            return MessageBox.Show(
                message,
                title,
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        public bool ShowMessage(string message, string title)
        {
            MessageBox.Show(
                message,
                title,
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            return true;
        }
    }
}
