using Xamarin.Forms;
using prismXamarin.Views;
using prismXamarin.ViewModels;
using Prism;
using Prism.Ioc;

namespace prismXamarin
{
    public partial class App
    {
        public App()
        {
        }
        public App(IPlatformInitializer platformInitializer)
            : base (platformInitializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewMode>();
            containerRegistry.RegisterForNavigation<MyContentPage, MyContentPageViewModel>();
        }
    }
}
