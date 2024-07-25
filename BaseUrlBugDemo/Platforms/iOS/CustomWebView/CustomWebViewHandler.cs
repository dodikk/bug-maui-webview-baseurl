using System;
using Microsoft.Maui.Handlers;
using WebKit;

namespace BaseUrlBugDemo.Platforms.iOS.CustomWebView;
public class CustomWebViewHandler: WebViewHandler
{
    protected override WKWebView CreatePlatformView()
    {
        return new CustomMauiWkWebViewIos(handler: this);
    }
}

