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

    }
}
