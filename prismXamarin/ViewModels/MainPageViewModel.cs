using Prism.Mvvm;
using Prism.Navigation;
using Prism.Commands;

namespace prismXamarin.ViewModels
{
    public class MainPageViewMode : BindableBase, IInitialize, INavigationAware, IDestructible 
    {
        protected INavigationService NavigationService { get; private set; }

        public MainPageViewMode(INavigationService navigationService)
        {
            NavigationService = navigationService;
            ButtonLabel = new DelegateCommand(ButtonLabel_Click);
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

        #region ラベル
        private string _labelButton = "ボタンを押すと表示が変わります";
        public string LabelButton
        {
            get => _labelButton;
            set => SetProperty(ref _labelButton, value);
        }
        #endregion

        #region ラベルボタン
        public DelegateCommand ButtonLabel { get; set; }
        private void ButtonLabel_Click()
        {
            LabelButton = "ボタンが押されました";
        }
        #endregion
    }
}
