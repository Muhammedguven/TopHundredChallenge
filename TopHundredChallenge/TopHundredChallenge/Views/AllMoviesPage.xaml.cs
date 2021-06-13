using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopHundredChallenge.Database;
using TopHundredChallenge.Infra;
using TopHundredChallenge.Models;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TopHundredChallenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllMoviesPage : ContentPage
    {
        public ObservableCollection<MovieList> movies;
        public AllMoviesPage()
        {
            InitializeComponent();
            movies = new ObservableCollection<MovieList>();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            movies.Clear();
            progressBar.IsVisible = true;
            progressBar.Progress = 0;
            await progressBar.ProgressTo(0.99, 500, Easing.Linear);
            var result = await App.imdbManager.GetTopHundredMoviesAsync();
            var watchedMovies = await SQLiteDb.GetMoviesAsync();
            foreach (var item in result.movie_list)
            {
                movies.Add(item);
            }
            foreach (var item in watchedMovies)
            {
                var watchedMovie = result.movie_list.Find(a => a.ranking == Convert.ToString(item.MovieRank));
                movies.Remove(watchedMovie);
            }
            progressBar.IsVisible = false;
            movieListView.ItemsSource = movies;
        }

        private async Task OpenAnimation(View view, uint length = 250)
        {
            view.RotationX = -90;
            view.IsVisible = true;
            view.Opacity = 0;
            _ = view.FadeTo(1, length);
            await view.RotateXTo(0, length);
        }

        private async Task CloseAnimation(View view, uint length = 250)
        {
            _ = view.FadeTo(0, length);
            await view.RotateXTo(-90, length);
            view.IsVisible = false;
        }

        private async void MainExpander_Tapped(object sender, EventArgs e)
        {
            var expander = sender as Expander;
            var imgView = expander.FindByName<Grid>("ImageView");
            var detailsView = expander.FindByName<Grid>("DetailsView");

            if (expander.IsExpanded)
            {
                await OpenAnimation(imgView);
                await OpenAnimation(detailsView);
            }
            else
            {
                await CloseAnimation(detailsView);
                await CloseAnimation(imgView);
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string ranking = (string)button.CommandParameter;
            MovieList movie;
            movie = movies.FirstOrDefault(a => a.ranking == ranking);
            int result = await SQLiteDb.SaveMovieAsync(new SpecificMovie { MovieRank = Convert.ToInt32(movie.ranking) });
            if (result == 1)
            {
                DependencyService.Get<ISnackInterface>().SnackbarShow(movie.Title + " moved to Watched List.");
                movies.Remove(movie);
            }
            else
                DependencyService.Get<ISnackInterface>().SnackbarShow("Someting went wrong. Try again!");
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            string url = (string)button.CommandParameter;
            if (url != null)
            {
                Navigation.PushAsync(new ImageDetailPage(url));
            }
            else
            {
                DependencyService.Get<ISnackInterface>().SnackbarShow("There is no video for this movie!");
            }
        }
    }
}