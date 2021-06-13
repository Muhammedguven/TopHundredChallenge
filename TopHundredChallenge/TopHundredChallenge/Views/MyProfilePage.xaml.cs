using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopHundredChallenge.Database;
using TopHundredChallenge.Infra;
using TopHundredChallenge.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TopHundredChallenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfilePage : ContentPage
    {
        public int numberOfWatchedMovies;
        List<ChartEntry> entries = new List<ChartEntry>();

        public MyProfilePage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(4), () => {

                Device.BeginInvokeOnMainThread(() => SliderEffect());
                return true;
            });
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            entries.Clear();
            progressBar.IsVisible = true;
            progressBar.Progress = 0;
            await progressBar.ProgressTo(0.99, 500, Easing.Linear);
            var watchedMovies = await SQLiteDb.GetMoviesAsync();
            numberOfWatchedMovies = watchedMovies.Count();
            chart.Chart = new  DonutChart { Entries = entries, BackgroundColor = SKColors.Transparent, LabelColor = SKColor.Parse("#D81F26") };
            progressBar.IsVisible = false;
            entries.Add(
                new ChartEntry(numberOfWatchedMovies)
                {
                    Color = SkiaSharp.SKColor.Parse("#D81F26"),
                    Label = "Already watched movies",
                    ValueLabel = numberOfWatchedMovies.ToString()
                });
            entries.Add(
                new ChartEntry(100-numberOfWatchedMovies)
                {
                    Color = SkiaSharp.SKColor.Parse("#111111 "),
                    Label = "Number of movies to watch",
                    ValueLabel = (100-numberOfWatchedMovies).ToString()
                }
                );
            var dependency = DependencyService.Get<INativeFont>();
            chart.Chart.LabelTextSize = dependency.GetNativeSize(14);
        }
        public async void SliderEffect()
        {
            await logo.ScaleTo(1.3, 800, Easing.SpringIn);
            await logo.ScaleTo(1.0, 400, Easing.SpringOut);
        }

    }
}