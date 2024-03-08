using Android.App;
using Android.Content.PM;
using Android.Content;
using Android.Net;
using VpnHood.Client.Device.Droid;
using Android.OS;
using Android.Runtime;
using VpnHood.Client;

namespace VpnBlazor;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override async void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        await Prepare();
    }
    public async Task Prepare()
    {
        VpnService.Builder builder = new VpnService.Builder(vpnService);
        builder.AddAddress("121.168.45.38", 32);
        builder.AddRoute("0.0.0.0", 0);
        var vpn = builder.Establish();
        StartActivity();

        //builder.SetConfigureIntent(pendingIntent);

        // builder.SetSession();

    }
}
