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

**CUSTOM CONTROLS**

You can use the provided custom controls that implement the fix for HeightRequest:

```xml
<controls:MVActivityIndicator x:Name="activityIndicator" IsRunning="true"/>
<controls:MVButton x:Name="button" Text="Remove this page" Clicked="Handle_Clicked"/>
<controls:MVDatePicker x:Name="datePicker" />
<controls:MVEditor x:Name="editor" BackgroundColor="Silver"/>
<controls:MVEntry x:Name="entry" />
<controls:MVPicker x:Name="picker" />
<controls:MVProgressBar x:Name="progressBar" Progress="0.5" />
<controls:MVSearchBar x:Name="searchBar" />
<controls:MVSlider x:Name="slider" />
<controls:MVStepper x:Name="stepper" />
<controls:MVSwitch x:Name="myswitch" />
<controls:MVTimePicker x:Name="timePicker" />
<controls:MVLabel x:Name="label" Text="My Label"/>
```

If you have your own custom renderers they will have to ExportRenderer for this controls:

```
[assembly: ExportRenderer (typeof(MVButton), typeof(MyButtonRenderer))]
```

If you don't want to use them, as an alternative, take a look at these code snippet so you know what to do with your own controls:

```
public class MVLabel : Label // REQUIRED
{
	public CVLabel()
	{
		SetBinding(Label.HeightRequestProperty, new Binding("WidthRequest", BindingMode.Default, new LabelHeightConverter(), this, null, this));
	}

	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);

		WidthRequest = width;

		this.LayoutTo(new Rectangle(this.X, this.Y, width, height));

		this.InvalidateMeasure();
	}
}

public class MVButton : Button 
{
	public CVButton()
	{
		if (HeightRequest == -1)
		{
			switch (Device.OS)
			{
				case TargetPlatform.iOS:
					HeightRequest = 44;
					break;
				case TargetPlatform.Android:
					HeightRequest = 48;
					break;
				default:
					HeightRequest = 32;
					break;
			}
		}
	}
}
```

**Default HeightRequest by platform**

|Control|iOS|Android|UWP|
| ------------------- | :-----------: | :-----------: | :------------------: |
|ActivityIndicator|20|48|4|
|Button|44|48|32|
|DatePicker|30|45.5|32|
|Editor|36.5|45.5|32|
|Entry|30|45.5|32|
|Picker|30|45.5|32|
|ProgressBar|2|16|4|
|Searchbar|44|45|32|
|Slider|34|18|44|
|Stepper|29|48|32|
|Switch|31|27|40|
|TimePicker|30|45.5|32|

You can also use these values if you don't use the provided controls neither implement your own.

```xml
<Button.HeightRequest>
        <OnPlatform x:TypeArguments="x:Double"
                Android="48"
                WinPhone="32"
                iOS="44" />
</Button.HeightRequest>
```

#### Known issues

- Horizontal StackLayout doesn't works. Why? No idea :) You may use a multi-column Grid instead.

#### Contributors
* [alexrainman](https://github.com/alexrainman)

Thanks!

#### License
Licensed under repo license
