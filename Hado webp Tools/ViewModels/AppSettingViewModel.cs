// Ignore Spelling: App

using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Windows.AppLifecycle;
using Windows.ApplicationModel.Core;

namespace WEBPHUB.ViewModels;

public partial class AppSettingViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _violateCondition = false;

    [ObservableProperty]
    private bool _enableDark;

    [ObservableProperty]
    private bool _enableLight;

    public AppSettingViewModel()
    {
        int theme = (int)ApplicationData.Current.LocalSettings.Values["themeSetting"];

        if (theme == 0)
        {
           EnableDark = true;
           EnableLight = false;
        }
        else
        {
            EnableDark = false;
            EnableLight = true;
        }
            
    }

    public void ToDark()
    {
        if (App.IsProcessing is false)
        {
            ApplicationData.Current.LocalSettings.Values["themeSetting"] = 1;
            var error = AppInstance.Restart("--restart");
        }
        else
        {
            ViolateCondition = true;
        }
        
    }

    public void ToLight()
    {
        if (App.IsProcessing is false)
        {
            ApplicationData.Current.LocalSettings.Values["themeSetting"] = 0;
            var error = AppInstance.Restart("--restart");
        }
        else
        {
            ViolateCondition = true;
        }
        
    }

}
