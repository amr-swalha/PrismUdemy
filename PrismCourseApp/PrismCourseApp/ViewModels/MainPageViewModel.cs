using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prism.Events;
using System;
using PrismCourseApp.Events;
using System.Threading.Tasks;

namespace PrismCourseApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware,IConfirmNavigationAsync
    {
        public IEventAggregator _eventAggregator;
        private INavigationService _navigationService;
        public DelegateCommand GoToSecond { get; private set; }
        public DelegateCommand UnSubscribeEvent { get; private set; }
        public DelegateCommand SubscribeEvent { get; private set; }
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
        public MainPageViewModel(INavigationService navigationService,
            IPageDialogService dialogService,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            _dialogService = dialogService;
            GoToSecond = new DelegateCommand(GoToSecondNavigation).ObservesCanExecute(() => IsActive);
            CallMsg = new DelegateCommand(ShowMsg);
            DisplayActionSheet = new DelegateCommand(ShowActionSheet);
            GoToAPI = new DelegateCommand(NavigateToAPI);
            GoDs = new DelegateCommand(GoDsNavigate);
            UnSubscribeEvent = new DelegateCommand(UnSubScribeFromEvent);
            SubscribeEvent = new DelegateCommand(SubscribeToEvent);
        }

        private void SubscribeToEvent()
        {
            _eventAggregator.GetEvent<EventPub>().Subscribe(ChangeCityName);
        }

        private void UnSubScribeFromEvent()
        {
            _eventAggregator.GetEvent<EventPub>().Unsubscribe(ChangeCityName);
        }

        private void ChangeCityName(string obj)
        {

            CityName = obj;
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

        public Task<bool> CanNavigateAsync(NavigationParameters parameters)
        {
            return _dialogService.DisplayAlertAsync("Going Away", "Are you sure", "Yes", "No");
        }
    }
}
