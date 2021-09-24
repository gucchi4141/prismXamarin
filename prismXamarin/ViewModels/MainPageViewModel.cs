using Prism.Mvvm;
using Prism.Navigation;
using Prism.Commands;

using Plugin.Media;
using Xamarin.Forms;

namespace prismXamarin.ViewModels
{
    public class MainPageViewMode : BindableBase, IInitialize, INavigationAware, IDestructible 
    {
        protected INavigationService NavigationService { get; private set; }

        public MainPageViewMode(INavigationService navigationService)
        {
            NavigationService = navigationService;
            ButtonPicture = new DelegateCommand(ButtonPicture_Click);
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

        #region 写真
        private ImageSource _imagePicture = null;
        public ImageSource ImagePicture
        {
            get => _imagePicture;
            set => SetProperty(ref _imagePicture, value);
        }
        #endregion

        #region 撮影ボタン
        public DelegateCommand ButtonPicture { get; set; }
        private async void ButtonPicture_Click()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable ||
                !CrossMedia.Current.IsTakePhotoSupported)
            {
                return;
            }
            var mediaOption = new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "myPicture",
                Name = $"{System.DateTime.UtcNow}.jpg"
            };

            var file = await CrossMedia.Current.TakePhotoAsync(mediaOption);
            if(null == file)
            {
                return;
            }

            ImagePicture = ImageSource.FromStream(() =>
            {
                return file.GetStream();
            });
        }
        #endregion
    }
}
