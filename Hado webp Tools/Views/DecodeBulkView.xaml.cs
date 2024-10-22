namespace WEBPHUB.Views;

public sealed partial class DecodeBulkView : Page
{
    public static WebpCenterModel WebpManager { get; private set; }
    public static string FormatType { get; set; } = ".png";

    public DecodeBulkView()
    {
        InitializeComponent();
        DataContext = new DecodeBulkViewModel();
        WebpManager = new();
    }
}
