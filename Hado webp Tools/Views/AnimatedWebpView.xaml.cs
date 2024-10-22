// Ignore Spelling: Webp

namespace WEBPHUB.Views;

public sealed partial class AnimatedWebpView : Page
{
    public static WebpCenterModel WebpManager { get; private set; }

    public AnimatedWebpView()
    {
        InitializeComponent();
        WebpManager = new WebpCenterModel();
        DataContext = new EncodeAnimatedWebpViewModel();
    }
}
