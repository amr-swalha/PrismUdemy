using Newtonsoft.Json;
using Prism.Mvvm;
using Prism.Navigation;
using PrismCourseApp.API;
using PrismCourseApp.Models;
using System.Net.Http;

namespace PrismCourseApp.ViewModels
{
    public class APIPageViewModel : BindableBase,INavigationAware
    {
        APIHandler api = new APIHandler();
        private RootObject _weather;
        public RootObject Weather
        {
            get { return _weather; }
            set { SetProperty(ref _weather, value); }
        }
        private INavigationService _navigationService;
        public APIPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
            Weather = api.GetData(parameters["city"].ToString());
        }
    }
}
