using System.Windows;

namespace TheatreDesktop.Services
{
    public class ApplicationService : IApplicationService
    {
        public void Shutdown()
        {
            Application.Current.Shutdown();
        }
    }
}
