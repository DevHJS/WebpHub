// Ignore Spelling: App

namespace WEBPHUB;

public sealed partial class MainWindow : Window
{
    public static AppWindowTitleBar AppTitleBar { get; private set; }
    public MainWindow()
    {
        InitializeComponent();
        ContentFrame.Navigate(typeof(GuideView), ContentFrame);
        ExtendsContentIntoTitleBar = true;
        AppTitleBar = AppWindow.TitleBar;
    }

    private void MainNavigation_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        var selectedItem = (NavigationViewItem)args.SelectedItem;
        if (selectedItem is not null)
        {
            var pageName = $"WEBPHUB.Views.{selectedItem.Tag}View";
            var pageType = Type.GetType(pageName);
            ContentFrame.Navigate(pageType);
        }
    }
}
