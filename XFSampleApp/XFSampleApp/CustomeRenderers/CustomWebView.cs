﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XFSampleApp.Helpers;

namespace XFSampleApp.CustomeRenderers
{
    public class CustomWebView : WebView
    {
        Action<string> action;

        public static readonly BindableProperty UriProperty = BindableProperty.Create(
               propertyName: "Uri",
               returnType: typeof(string),
               declaringType: typeof(CustomWebView),
               defaultValue: default(string));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }

        public void RegisterAction(Action<string> callback)
        {
            action = callback;
        }

        public void Cleanup()
        {
            action = null;
        }

        public void InvokeAction(string data)
        {
             action?.Invoke(data);
        }

        public IEvalJs EvalJsInstance { get; set; }

        public void EvalJavaScript(string script)
        {
            EvalJsInstance?.ExecuteJavaScript(script);
        }
    }
}

