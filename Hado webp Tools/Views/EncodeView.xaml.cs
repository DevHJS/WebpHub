// Ignore Spelling: Webp

namespace WEBPHUB.Views;

public sealed partial class EncodeView : Page
{
    public static WebpCenterModel WebpManager { get; private set; }
    public EncodeView()
    {
        WebpManager = new WebpCenterModel();
        DataContext = new EncodeViewModel();
        InitializeComponent();
    }
}
