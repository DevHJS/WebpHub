// Ignore Spelling: Webp

using WEBPHUB.Models;
using WEBPHUB.ViewModels;
using Microsoft.UI.Xaml.Controls;



namespace WEBPHUB.Views;

public sealed partial class DecodeView : Page
{
    public static WebpCenterModel WebpManager { get; private set; }
    public DecodeViewModel ViewModel { get; set; } = new();
    public static string FormatType { get; set; } = ".png";
    public DecodeView()
    {
        this.InitializeComponent();
        DataContext = ViewModel;
        WebpManager = new WebpCenterModel();
    }
}
