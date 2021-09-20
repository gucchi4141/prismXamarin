using Prism.Mvvm;
using Prism.Navigation;

namespace prismXamarin.ViewModels
{
    public class MainPageViewMode : BindableBase, IInitialize, INavigationAware, IDestructible 
    {
        protected INavigationService NavigationService { get; private set; }

        public MainPageViewMode(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
