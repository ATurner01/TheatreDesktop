namespace TheatreDesktop.Services
{
    public interface IDialogService
    {
        bool Confirm(string message, string title);
        bool ShowMessage(string message, string title);
    }
}
