using System;
using TopHundredChallenge.Services.Concrete;
using TopHundredChallenge.Services.Manager;
using TopHundredChallenge.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TopHundredChallenge
{
    public partial class App : Application
    {
        public static ImdbManager imdbManager { get; private set; }
        public App()
        {
            InitializeComponent();

            imdbManager = new ImdbManager(new ImdbService());

            MainPage = new HomePage();
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
