iOSVolumeTest
=============

Xamarin project to test ways of listening for presses of the volume hardware buttons.

The goal is to get an event when someone presses the volume-up or -down buttons.  In our case, a radio streaming app,
we are using the BASS.Net audio library to stream the audio, rather than `MPMusicPlayer.play()`.

We also tried initiating an AudioSession via

```cs
            NSError error;
            instance = AVAudioSession.SharedInstance();
            instance.SetCategory(new NSString("AVAudioSessionCategoryPlayback"), AVAudioSessionCategoryOptions.MixWithOthers, out error);

            instance.SetMode(new NSString("AVAudioSessionModeDefault"), out error);

            instance.SetActive(true, AVAudioSessionSetActiveOptions.NotifyOthersOnDeactivation, out error);
```

but that had no effect either.




