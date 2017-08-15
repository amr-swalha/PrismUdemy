using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace PrismCourseApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;
        public DelegateCommand GoToSecond { get; private set; }
        public DelegateCommand CallMsg { get; private set; }
        public DelegateCommand GoToAPI { get; private set; }
        public DelegateCommand DisplayActionSheet { get; private set; }
        public DelegateCommand GoDs { get; private set; }
        private string _CityName;
        public string CityName
        {
            get { return _CityName; }
            set { SetProperty(ref _CityName, value); }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private bool _isActive = false;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }
        public IPageDialogService _dialogService { get; set; }

        public MainPageViewModel(INavigationService navigationService,IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            GoToSecond = new DelegateCommand(GoToSecondNavigation).ObservesCanExecute(() => IsActive);
            CallMsg = new DelegateCommand(ShowMsg);
            DisplayActionSheet = new DelegateCommand(ShowActionSheet);
            GoToAPI = new DelegateCommand(NavigateToAPI);
            GoDs = new DelegateCommand(GoDsNavigate);
        }
        public void NavigateToAPI()
        {
            _navigationService.NavigateAsync($"APIPage?city={CityName}");
        }
        public void GoDsNavigate()
        {
            _navigationService.NavigateAsync($"DsPage");
        }
        public async void ShowActionSheet()
        {
           string result = await _dialogService.DisplayActionSheetAsync("I'm Action Sheet", "Cancel", null, "action 1", "action 2", "action 3", "action 4");
            result = result;
        }
        public async void ShowMsg()
        {
           bool result = await _dialogService.DisplayAlertAsync("Hello", "i'm a msg", "OK!","Cancel :(");
            result = result;
        }
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
        public void GoToSecondNavigation()
        {
            var par = new NavigationParameters();
            par.Add("par1", "val1");
            par.Add("par2", "val2");
            _navigationService.NavigateAsync("SecondPage", par);
        }
    }
}
