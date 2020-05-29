
using Android.App;
using Android.Content.PM;
using Android.OS;
using WorkingWithMaps.Droid;

namespace PropertyApp.Droid
{
    [Activity(Label = "GoPlay",
              Theme = "@style/SplashTheme",
              MainLauncher = true,
              NoHistory = true,
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplasActividad : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
            // Create your application here
        }
    }
}