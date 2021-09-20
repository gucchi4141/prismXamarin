using Prism.Mvvm;
using Prism.Navigation;

namespace prismXamarin.ViewModels
{
    public class MyContentPageViewModel : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        public MyContentPageViewModel(INavigationService navigationService)
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

        #region Message
        private string _message = "My Content Page.";
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        #endregion

    }
}
