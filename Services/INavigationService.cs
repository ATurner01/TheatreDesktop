namespace TheatreDesktop.Services
{
    public interface INavigationService
    {
        public void NavigateTo<TViewModel>();
        public void NavigateTo<TViewModel, TParameter>(TParameter parameter);
    }
}
