using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using EminentTest.Helpers;

namespace EminentTest.Droid
{
    [Activity (Label = "CustomerSchemeInterceptorActivity", NoHistory =true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    [IntentFilter(
        new[] { Intent.ActionView}, 
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable},
        DataSchemes = new[] { "com.googleusercontent.app.264733134350-49o7jvr9ij50fdhon3tc0s2im9527lnd.apps.googleusercontent.com" },
        DataPath ="/oauth2redirect")]
    public class CustomUrl : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var url = new Url(Intent.Data.ToString());

            AuthenticationState.Authenticator.OnPageLoading(url);
            var intent = new Intent(this, typeof(MainActivity));
            Intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
            StartActivity(Intent);
            this.Finish();
            return;
        }
    }
}