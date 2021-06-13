using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode;

namespace TopHundredChallenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageDetailPage : ContentPage
    {
        public ImageDetailPage(string url)
        {
            InitializeComponent();
            GetVideoContent(url);
        }
        private async void GetVideoContent(string videUrl)
        {
            myIndicator.IsVisible = true;
            var youtube = new YoutubeClient();

            var video = await youtube.Videos.GetAsync(videUrl);
            var title = video.Title;
            var author = video.Author;
            var duration = video.Duration;

            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videUrl);

            var streamInfo = streamManifest.GetMuxedStreams().First();
            if (streamInfo != null)
            {
                var stream = await youtube.Videos.Streams.GetAsync(streamInfo);
                myVideo.Source = streamInfo.Url;
            }
        }

        private void MediaElement_MediaOpened(object sender, EventArgs e)
        {
            myIndicator.IsVisible = false;
        }

        private async void closeButton_Clicked(object sender, EventArgs e)
        {
            myVideo.Stop();
            await Navigation.PopAsync();
        }
    }
}