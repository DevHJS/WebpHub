// Ignore Spelling: Webp

namespace WEBPHUB.Views;

public sealed partial class EncodeBulkView : Page
{
    public static WebpCenterModel WebpManager { get; private set; }

    public EncodeBulkView()
    {
        InitializeComponent();
        WebpManager = new();
        DataContext = new EncodeBulkViewModel();
    }
}
