using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Snackbar;
using Plugin.CurrentActivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopHundredChallenge.Droid;
using TopHundredChallenge.Infra;

[assembly: Xamarin.Forms.Dependency(typeof(SnackBar_Android))]
namespace TopHundredChallenge.Droid
{
    public class SnackBar_Android : ISnackInterface
    {
        public void SnackbarShow(string message)
        {
            Activity activity = CrossCurrentActivity.Current.Activity;
            Android.Views.View view = activity.FindViewById(Android.Resource.Id.Content);
            Snackbar.Make(view, message, Snackbar.LengthShort).Show();
        }
    }
}