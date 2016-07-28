# ModalView Plugin for Xamarin Forms

#### Setup
* Available on NuGet: https://www.nuget.org/packages/Plugin.ModalView/ [![NuGet](https://img.shields.io/nuget/v/Plugin.ModalView.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.ModalView/)
* Install in your PCL project and Client projects.

**Platform Support**

|Platform|Supported|Version|Renderer|
| ------------------- | :-----------: | :-----------: | :------------------: |
|Xamarin.iOS Unified|Yes|iOS 8.1+|UIViewController|
|Xamarin.Android|Yes|API 15+|AlertDialog|

#### Usage

Push a custom modal:

```
var view = new MyModalView();
var desiredheight = Device.OS == TargetPlatform.iOS ? 190 : 260;
CrossModalView.Current.PushCustomModal(view, desiredheight, false); 
```

- view: ContentView
- desiredHeight: double, indicates the height of the modal view (Optional, default full screen).
- Be aware the requested height for the modal view will be higher in Android.
- cornerRadius: bool (Optional, default true, iOS only)

Pop a custom modal:

```
CrossModalView.Current.PopCustomModal();
```

### Provided custom controls

You have to use custom controls for Button, Label, Picker and Switch (overriding the original renderer doesn't works in AlertDialog in Android)

First add the xmlns namespace:

```xml
xmlns:controls="clr-namespace:Plugin.ModalView.Abstractions;assembly=Plugin.ModalView.Abstractions"
```

Then add the xaml:

```xml
<controls:MVButton Text="Click me!" />
<controls:MVLabel Text="Some text." />
<controls:MVPicker />
<controls:MVSwitch />
```

#### Known issues

- Horizontal StackLayout doesn't works. Why? No idea :) You may use a multi-column Grid instead.

#### Contributors
* [alexrainman](https://github.com/alexrainman)

Thanks!

#### License
Licensed under repo license
