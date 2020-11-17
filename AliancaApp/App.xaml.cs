using AliancaApp.Services;
using AliancaApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AliancaApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockActivites>();
            DependencyService.Register<MockNews>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
