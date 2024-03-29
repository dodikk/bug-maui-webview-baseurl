//
//  ViewController.swift
//  BaseUrlNativeDemo
//
//  Created by dodd on 10.01.2024.
//

import UIKit
import WebKit


class ViewController: UIViewController, WKUIDelegate
{
    @IBOutlet weak var captchaWebView: WKWebView!
    @IBOutlet weak var legacyWebView: UIWebView!
    
    override func viewDidLoad()
    {
        super.viewDidLoad();
        
        captchaWebView.uiDelegate = self;
    }
    
    override func viewDidAppear(_ animated: Bool)
    {
        super.viewDidAppear(animated);
        
        
        LogBundleAndUrls();
        
        
        
        
        let urlOfCaptchaPage =
            Bundle.main.url(
                forResource: "CaptchaPageTemplate.html",
                withExtension: "txt");
        
        let captchaPageHtml: String = try! String(contentsOf: urlOfCaptchaPage!);
        let wrappedBaseUrl = URL(string: _rawBaseUrl);
        
        captchaWebView.loadHTMLString(
            captchaPageHtml,
            baseURL: wrappedBaseUrl)
        
        legacyWebView.loadHTMLString(
            captchaPageHtml,
            baseURL: wrappedBaseUrl)
    }
    
    func webView(
        _ webView: WKWebView,
        runJavaScriptAlertPanelWithMessage message: String,
        initiatedByFrame frame: WKFrameInfo,
        completionHandler: @escaping () -> Void)
    {
       let alert = UIAlertController(
           title: nil,
           message: message,
           preferredStyle: .alert
       )

       let okAction = UIAlertAction(
           title: "OK",
           style: .default,
           handler:
           {
                _ in
                completionHandler()
           }
       )
       alert.addAction(okAction)

       present(alert, animated: true, completion: nil)
    }
    
    private func LogBundleAndUrls()
    {
        NSLog(Bundle.main.bundlePath);
        
        if let combinedPathLikeInMaui = Bundle.main.path(forResource: _rawBaseUrl, ofType: nil)
        {
            NSLog(combinedPathLikeInMaui);
        }
        
        if let combinedUrlLikeInMaui = Bundle.main.url(forResource: _rawBaseUrl, withExtension: nil)
        {
            NSLog("\(combinedUrlLikeInMaui)");
        }
    
        
    }
    
    private let _rawBaseUrl = "https://identity-dev.coinpaymints.com";
}

