# Calendar Control for Xamarin.Forms
A Calendar Control for Xamarin.Forms

## Setup

* Available on NuGet: [![NuGet](https://img.shields.io/nuget/v/XamCal.svg?label=NuGet)](https://www.nuget.org/packages/XamCal)
* Install into your PCL/.NET Standard and Client Projects

## Build

* [![Build status](https://ci.appveyor.com/api/projects/status/80oprj0yo239p5ek?svg=true)](https://ci.appveyor.com/project/ahoefling/xamcal)
* CI NuGet Feed: [https://ci.appveyor.com/nuget/XamCal](https://ci.appveyor.com/nuget/XamCal)
    
### Screenshots

![Sample Project](/images/sample.png)

### Platform Support
CircleButtonMenu is available for use in the following supported platforms.

| Platform         | Supported | Version     |
|------------------|-----------|-------------|
| Xamarin.Android  | Yes       | TBD +       |
| Xamarin.iOS      | Yes       | TBD +       |


## Usage ##

#### iOS and Android ####
Initialize the renderer in the AppDelegate (iOS) and MainActivity (Android)

```c#
Xamarin.Forms.Init();
XamCalRenderer.Init();
```

### XAML: ####
Add the namespace in the xmlns:

```xml
xmlns:controls="clr-namespace:XamCal.Abstractions;assembly=XamCal.Abstractions"
```

Add the control:

TODO show other usages

```xml
<controls:Calendar Month="1"
                   Year="2018" />
```

## Bindable Properties

| Property          | Type                 | Description                                                 |
|-------------------|----------------------|-------------------------------------------------------------|
| Month             | `int`                | The current month to render                                 |
| Year              | `int`                | The current year to render                                  |
| Events            | `IEnumerable<Event>` | The events for the selected month/year                      |
| DayTemplate       | `DataTemplate`       | A `DataTemplate` that will render for each day of the month |
| DaySelected       | `ICommand`           | The `ICommand` to execute when the user taps on a day       |


## Created By: [@Andrew_Hoefling](https://twitter.com/andrew_hoefling)

* Twitter: [@Andrew_Hoefling](https://twitter.com/andrew_hoefling)
* Blog: [andrewhoefling.com](http://www.andrewhoefling.com)

### License

The MIT License (MIT) see License File