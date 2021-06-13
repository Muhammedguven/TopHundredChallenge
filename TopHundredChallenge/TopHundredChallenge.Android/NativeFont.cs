﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopHundredChallenge.Droid;
using TopHundredChallenge.Infra;

[assembly: Xamarin.Forms.Dependency(typeof(NativeFont))]
namespace TopHundredChallenge.Droid
{
    public class NativeFont : INativeFont
    {
        public float GetNativeSize(float size)
        {
            var displayMetrics = Android.App.Application.Context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, size, displayMetrics);
        }
    }
}