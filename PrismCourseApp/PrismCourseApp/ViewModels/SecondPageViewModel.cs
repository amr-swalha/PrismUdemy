using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismCourseApp.ViewModels
{
    public class SecondPageViewModel : BindableBase, INavigationAware
    {
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
