using System;
using System.Collections.Generic;
using Prism.Navigation;

namespace prismXamarin.ViewModels
{
    public class MyContentPageViewModel : ViewModelsBase
    {
        public MyContentPageViewModel(INavigationService navigationService)
            :base(navigationService)
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

        #region メイン画面からのメッセージ
        private string _mainPageMsg = string.Empty;
        public string MainPageMsg
        {
            get => _mainPageMsg;
            set => SetProperty(ref _mainPageMsg, value);
        }
        #endregion

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            MainPageMsg = parameters["msg"].ToString();
        }
    }
}
