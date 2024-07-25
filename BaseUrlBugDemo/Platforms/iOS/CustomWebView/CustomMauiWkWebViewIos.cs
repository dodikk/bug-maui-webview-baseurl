using System;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

// ---
// ios native frameworks
// ---
using Foundation;
using CoreGraphics;
using WebKit;


namespace BaseUrlBugDemo.Platforms.iOS.CustomWebView;
public class CustomMauiWkWebViewIos: MauiWKWebView, IWebViewDelegate
{
    public CustomMauiWkWebViewIos(WebViewHandler handler): base(handler)
    {
    }

    public CustomMauiWkWebViewIos(
        CGRect frame,
        WebViewHandler handler
    ): base(frame, handler)
    {
    }

    public CustomMauiWkWebViewIos(
        CGRect frame,
        WebViewHandler handler,
        WKWebViewConfiguration configuration
    ): base(frame, handler, configuration)
    {
    }


    void IWebViewDelegate.LoadHtml(string html, string baseUrl)
    {
        if (html == null)
        {
            return;
        }

        NSUrl normalizedBaseUrl =
            (baseUrl == null)
                ? new NSUrl(
                    path: NSBundle.MainBundle.BundlePath,
                    isDir: true)
                : new NSUrl(urlString: baseUrl);

        LoadHtmlString(
            htmlString: html,
            baseUrl: normalizedBaseUrl
        );
    }
}

