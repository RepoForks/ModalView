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
CrossModalView.Current.PushCustomModal(view, desiredHeight, cornerRadius); 
```

- view: ContentView
- desiredHeight: double, indicates the height of the modal view (optional, default full screen)
- cornerRadius: bool (optional, default true, iOS only)

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
<controls:MVLabel Text="Some text." />
```

#### Known issues

- Horizontal StackLayout doesn't works. Why? No idea :) You may use a multi-column Grid instead.

#### Contributors
* [alexrainman](https://github.com/alexrainman)

Thanks!

#### License
Licensed under repo license
