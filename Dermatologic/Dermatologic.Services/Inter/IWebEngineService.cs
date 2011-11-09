namespace Dermatologic.Services
{
    public interface IWebEngineService
    {
        void Navigate(Page page);
        void Navigate(string page);
    }
}