using Prism.Navigation;
using Prism.Commands;
using prismXamarin.Views;

namespace prismXamarin.ViewModels
{
    public class MainPageViewMode : ViewModelsBase
    {

        public MainPageViewMode(INavigationService navigationService)
            : base(navigationService)
        {

            ButtonLabel = new DelegateCommand(ButtonLabel_Click);
            ButtonMyContentPage = new DelegateCommand(ButtonMyContentPage_Click);
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

        #region MyContentPageの表示ボタン
        public DelegateCommand ButtonMyContentPage { get; set; }
        private void ButtonMyContentPage_Click()
        {
            NavigationService.NavigateAsync(nameof(MyContentPage));
        }
        #endregion
    }
}
