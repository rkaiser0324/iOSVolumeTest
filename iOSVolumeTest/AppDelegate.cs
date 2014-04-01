using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.MediaPlayer;

namespace iOSVolumeTest
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;
        MyViewController viewController;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            viewController = new MyViewController();
            window.RootViewController = viewController;

            window.MakeKeyAndVisible();

            // Try to observe presses to the system volume hardware buttons
            // See http://iosapi.xamarin.com/?link=P%3aMonoTouch.MediaPlayer.MPMusicPlayerController.VolumeDidChangeNotification
            NSObject observer = NSNotificationCenter.DefaultCenter.AddObserver(MPMusicPlayerController.VolumeDidChangeNotification,
                delegate(NSNotification notification)
                {
                    // This doesn't hit
                    Debug.WriteLine("Received a notification VolumeDidChangeNotification", notification);
                });

            NSNotificationCenter.DefaultCenter.AddObserver(MPVolumeView.WirelessRoutesAvailableDidChangeNotification, CallbackWireless);

            return true;
        }

        void CallbackWireless(NSNotification notification)
        {
            // This doesn't hit either
            Debug.WriteLine("Received a notification for WirelessRoutesAvailableDidChangeNotification", notification);
        }
    }
}

