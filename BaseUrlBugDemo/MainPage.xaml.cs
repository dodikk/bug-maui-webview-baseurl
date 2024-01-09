

namespace BaseUrlBugDemo;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        _ = InitWebViewAsync();
    }

    private async Task InitWebViewAsync()
    {
        try
        {
            PlainWebviewHtmlSource.BaseUrl = BaseUrlForCaptcha;

            string txtCaptchaHtmlTemplate = "";
            using (var htmlTemplateFileStream = await FileSystem.OpenAppPackageFileAsync("CaptchaPageTemplate.html.txt"))
            using (var htmlTemplateReader = new System.IO.StreamReader(htmlTemplateFileStream))
            {
                txtCaptchaHtmlTemplate = await htmlTemplateReader.ReadToEndAsync();
            }

            PlainWebviewHtmlSource.Html = txtCaptchaHtmlTemplate;
            PlainWebview.Reload();
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"WebView setup failed - {ex}");
            throw;
        }
    }

    private static string BaseUrlForCaptcha => "https://identity-dev.coinpaymints.com";
}


