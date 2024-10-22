namespace WEBPHUB.Views;

public sealed partial class AppSettingView : Page
{
    public AppSettingViewModel ViewModel { get; private set; }
    public AppSettingView()
    {
        ViewModel = new();
        InitializeComponent();
    }


}
