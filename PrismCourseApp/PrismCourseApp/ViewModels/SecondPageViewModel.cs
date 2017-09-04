using System;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Events;
using PrismCourseApp.Events;

namespace PrismCourseApp.ViewModels
{
    public class SecondPageViewModel : BindableBase, INavigationAware
    {
        public IEventAggregator _eventAggregator;
        public SecondPageViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<EventPub>().Publish("city name changed!");
        }
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("par1"))
            {
                string par1 = parameters["par1"].ToString();
                string par2 = parameters["par2"].ToString();
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }
    }
}
