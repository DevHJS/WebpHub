using System.Runtime.CompilerServices;
using Microsoft.Windows.AppLifecycle;
using Windows.ApplicationModel.Core;

namespace WEBPHUB.ViewModels;

public partial class AppSettingViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _violateCondition = false;

    public void ChangeTheme(object sender, SelectionChangedEventArgs e)
    {
        var control = (ComboBox)sender;
        var item = control.SelectedItem as ComboBoxItem;
        var content = item.Content as string;
        if (App.IsProcessing is false)
        {
            if (content.Contains("Light"))
            {
                ApplicationData.Current.LocalSettings.Values["themeSetting"] = 0;
                AppRestartFailureReason restartError = AppInstance.Restart("--restarted");
            }
            else
            {
                ApplicationData.Current.LocalSettings.Values["themeSetting"] = 1;
                AppRestartFailureReason restartError = AppInstance.Restart("--restarted");
            }
        }

        else
        {
            ViolateCondition = true;
        }
    }





}
