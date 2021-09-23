using Prism.Mvvm;
using Prism.Navigation;
using Prism.Commands;

using Prism.Services;
using PCLStorage;


namespace prismXamarin.ViewModels
{
    public class MainPageViewMode : BindableBase, IInitialize, INavigationAware, IDestructible 
    {
        protected INavigationService NavigationService { get; private set; }
        protected IPageDialogService PageDialogService { get; private set; }

        public MainPageViewMode(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
            // ボタンハンドラの登録
            ButtonSave = new DelegateCommand(ButtonSave_Click);
            ButtonLoad = new DelegateCommand(ButtonLoad_Click);
            ButtonDelete = new DelegateCommand(ButtonDelete_Click);
        }

        //
        IFolder _rootFolder = FileSystem.Current.LocalStorage;


        #region 入力データ
        private string _message = string.Empty;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        #endregion

        #region 結果
        private string _result = string.Empty;
        public string Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }
        #endregion

        #region 保存ボタン
        public DelegateCommand ButtonSave { get; set; }
        public async void ButtonSave_Click()
        {
            var file = await _rootFolder.CreateFileAsync("temp.txt", CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(Message);
            await PageDialogService.DisplayAlertAsync("Info", "ファイルに保存しました", "OK");
        }
        #endregion

        #region 読み出しボタン
        public DelegateCommand ButtonLoad { get; set; }
        public async void ButtonLoad_Click()
        {
            ExistenceCheckResult res = await _rootFolder.CheckExistsAsync("temp.txt");
            if(ExistenceCheckResult.FileExists == res)
            {
                var file = await _rootFolder.GetFileAsync("temp.txt");
                Result = await file.ReadAllTextAsync();
            }
            else
            {
                await PageDialogService.DisplayAlertAsync("Error", "ファイルが見つかりませんでした", "OK");
            }
        }
        #endregion

        #region 削除ボタン
        public DelegateCommand ButtonDelete { get; set; }
        public async void ButtonDelete_Click()
        {
            ExistenceCheckResult res = await _rootFolder.CheckExistsAsync("temp.txt");
            if(ExistenceCheckResult.FileExists == res)
            {
                var file = await _rootFolder.GetFileAsync("temp.txt");
                await file.DeleteAsync();
                await PageDialogService.DisplayAlertAsync("Info", "ファイルを削除しました", "OK");
            }
        }
        #endregion

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
