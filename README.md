# maui8titlebar

This sample shows a way to override the color of the Windows title bar in MAUI. You could actually use it to do other customizations based on the pattern here, once you have a handle to the titlebar container, you could do whatever you want with it. This sample uses MAUI Blazor but it should work fine in MAUI without Blazor.

These are the steps to add this to your own app:

1. Add the MauiWindowsTitlebar project reference to your MAUI app project.
2. In Platforms/Windows/App.xaml make it look like this:

```
<maui:MauiWinUIApplication
    x:Class="MauiWindowsTitlebarSample.WinUI.App"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:maui="using:Microsoft.Maui"
    xmlns:titlebar="using:MauiWindowsTitlebar.Platforms.Windows">
    <maui:MauiWinUIApplication.Resources>
        <DataTemplate x:Key="MauiAppTitleBarTemplate">
            <titlebar:TitleContainer HorizontalAlignment="Stretch">
                <TextBlock x:Name="AppTitle" Text="Hi" Margin="5"/>
            </titlebar:TitleContainer>
        </DataTemplate>
    </maui:MauiWinUIApplication.Resources>
</maui:MauiWinUIApplication>
```
The key parts of this are the declaration of the titlebar namespace, and then the definition of the DataTemplate.

It is important to use the x:Key MauiAppTitleBarTemplate for the DataTemplate, and x:Name AppTitle for the TextBlock. Also you must use TitleContainer as the root of your DataTemplate. This TitleContainer is just a Grid that has some special logic in it to set the titlebar values.

3. Now to set the color and title of your title bar, use the following methods (you should be able to put these where it makes sense for your app, I put them in MauiProgram.cs). I implemented the SetTitlebarColor to accept a MAUI color to make it easier to integrate.

```
   #if WINDOWS
            TitleContainer.SetTitle("MauiWindowsTitlebarSample");
            TitleContainer.SetTitlebarColor(Colors.Yellow);
   #endif
```
