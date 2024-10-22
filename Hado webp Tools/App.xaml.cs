// Ignore Spelling: App Exe Dwebp Cwebp Gif Webp

global using System;
global using System.Collections.Generic;
global using System.Collections.ObjectModel;
global using System.Diagnostics;
global using System.IO;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;
global using Microsoft.UI;
global using Microsoft.UI.Windowing;
global using Microsoft.UI.Xaml;
global using Microsoft.UI.Xaml.Controls;
global using WEBPHUB.InternalServices.ExtractorService;
global using WEBPHUB.InternalServices.OptionsBuilder;
global using WEBPHUB.Models;
global using WEBPHUB.ViewModels;
global using WEBPHUB.Views;
global using Windows.Storage;
global using Windows.Storage.Pickers;
global using WinRT.Interop;

namespace WEBPHUB;

public partial class App : Application
{
    public static MainWindow MWindow { get; private set; }
    public static string DefaultFolderPath { get; private set; }
    public static string CwebpFilePath { get; private set; }
    public static string DwebpFilePath { get; private set; }
    public static string Gif2WebpFilePath { get; private set; }
    public static bool IsProcessing { get; set; } = false;

    public App()
    {
        InitializeComponent();
        var theme = ApplicationData.Current.LocalSettings.Values["themeSetting"];
        if (theme is not null)
            Current.RequestedTheme = (ApplicationTheme)(int)theme;
       
    }

    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        MWindow = new MainWindow();
        MWindow.Activate();

        var hwnd = WindowNative.GetWindowHandle(MWindow);
        var wndId = Win32Interop.GetWindowIdFromWindow(hwnd);
        var appWindow = AppWindow.GetFromWindowId(wndId);
        var _presenter = appWindow.Presenter as OverlappedPresenter;
        _presenter.Maximize();

        string picPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        DefaultFolderPath = Path.Combine(picPath, "WebpHub");
        if (!Directory.Exists(DefaultFolderPath))
            Directory.CreateDirectory(DefaultFolderPath);

        var CwebpPath = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///ExeFiles/cwebp.exe"));
        CwebpFilePath = CwebpPath.Path;

        var DwebpPath = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///ExeFiles/dwebp.exe"));
        DwebpFilePath = DwebpPath.Path;

        var Gif2WebpPath = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///ExeFiles/gif2webp.exe"));
        Gif2WebpFilePath = Gif2WebpPath.Path;

        if (Current.RequestedTheme == ApplicationTheme.Light)
            MainWindow.AppTitleBar.ButtonForegroundColor = Colors.Black;
        else
            MainWindow.AppTitleBar.ButtonForegroundColor = Colors.White;
    }
}
