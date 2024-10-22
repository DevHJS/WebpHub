﻿namespace WEBPHUB.Views.SettingsControl;

public sealed partial class DecodeBulkSettingView : UserControl
{
    public DecodeOptionsBuilderService OptionsBuilder { get; private set; }
    private readonly DispatcherTimer timer;

    public DecodeBulkSettingView()
    {
        InitializeComponent();
        timer = new();
        OptionsBuilder = new();
    }

    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
        var format = FormatMethod.SelectedItem as ComboBoxItem;
        var formatType = (string)format.Content;

        if (formatType.Contains("PNG"))
        {
            OptionsBuilder.Format = string.Empty;
            DecodeBulkView.FormatType = ".png";
        }

        if (formatType.Contains("BMP"))
        {
            OptionsBuilder.Format = "-bmp";
            DecodeBulkView.FormatType = ".bmp";
        }

        if (formatType.Contains("TIFF"))
        {
            OptionsBuilder.Format = "-tiff";
            DecodeBulkView.FormatType = ".tif";
        }

        if (formatType.Contains("PPM"))
        {
            OptionsBuilder.Format = "-ppm";
            DecodeView.FormatType = ".ppm";
        }

        if (formatType.Contains("PGM"))
        {
            OptionsBuilder.Format = "-pgm";
            DecodeBulkView.FormatType = ".pgm";
        }

        if (formatType.Contains("PAM"))
        {
            OptionsBuilder.Format = "-pam";
            DecodeBulkView.FormatType = ".pam";
        }
        if (formatType.Contains("YUV"))
        {
            OptionsBuilder.Format = "-yuv";
            DecodeBulkView.FormatType = ".yuv";
        }

        if (NoAsmCheck.IsChecked == true)
            OptionsBuilder.NoAsm = "-noasm";

        if (MultiThreadedCheck.IsChecked == true)
            OptionsBuilder.MultiThreading = "-mt";

        if (NoDitherCheck.IsChecked == true)
            OptionsBuilder.NoDither = "-nodither";

        if (NoFancyCheck.IsChecked == true)
            OptionsBuilder.NoFancy = "-nofancy";

        if (NoFilterCheck.IsChecked == true)
            OptionsBuilder.NoFilter = "-nofilter";

        if (DitheringTxt.IsEnabled == true)
            OptionsBuilder.Dither = $"-dither {DitheringTxt.Text}";

        DecodeBulkView.WebpManager.Options = OptionsBuilder.ConstructOptions();

        SaveBtn.Content = "Saved!";
        timer.Interval = TimeSpan.FromSeconds(2);
        timer.Tick += Time_Tick;
        timer.Start();
    }

    private void Time_Tick(object sender, object e)
    {
        SaveBtn.Content = "Save";
        timer.Stop();
    }

    private void NoDitherCheck_Checked(object sender, RoutedEventArgs e)
    {
        DitheringTxt.IsEnabled = false;
    }

    private void NoDitherCheck_Unchecked(object sender, RoutedEventArgs e)
    {
        DitheringTxt.IsEnabled = true;
    }
}
