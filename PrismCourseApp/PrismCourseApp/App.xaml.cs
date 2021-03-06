﻿using Prism.Unity;
using PrismCourseApp.Views;
using Xamarin.Forms;
using PrismCourseApp.ViewModels;
using PrismCourseApp.API;
using Microsoft.Practices.Unity;

namespace PrismCourseApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<SecondPage,SecondPageViewModel>();
            Container.RegisterTypeForNavigation<APIPage>();
            Container.RegisterTypeForNavigation<DsPage>();
        }
    }
}
