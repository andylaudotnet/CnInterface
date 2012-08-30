﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.4927
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 2.0.50727.4927 版自动生成。
// 
#pragma warning disable 1591

namespace CnWeb.FlightWebService {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ABEServiceSoap", Namespace="http://tempuri.org/")]
    public partial class ABEService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ExcecuteCmdsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAVXMLOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRawDataFromABEOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ABEService() {
            this.Url = global::CnWeb.Properties.Settings.Default.CnWeb_FlightWebService_ABEService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ExcecuteCmdsCompletedEventHandler ExcecuteCmdsCompleted;
        
        /// <remarks/>
        public event GetAVXMLCompletedEventHandler GetAVXMLCompleted;
        
        /// <remarks/>
        public event GetRawDataFromABECompletedEventHandler GetRawDataFromABECompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ExcecuteCmds", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ExcecuteCmds(string cmd, string ABEConnStr, string key, bool isClose) {
            object[] results = this.Invoke("ExcecuteCmds", new object[] {
                        cmd,
                        ABEConnStr,
                        key,
                        isClose});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ExcecuteCmdsAsync(string cmd, string ABEConnStr, string key, bool isClose) {
            this.ExcecuteCmdsAsync(cmd, ABEConnStr, key, isClose, null);
        }
        
        /// <remarks/>
        public void ExcecuteCmdsAsync(string cmd, string ABEConnStr, string key, bool isClose, object userState) {
            if ((this.ExcecuteCmdsOperationCompleted == null)) {
                this.ExcecuteCmdsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnExcecuteCmdsOperationCompleted);
            }
            this.InvokeAsync("ExcecuteCmds", new object[] {
                        cmd,
                        ABEConnStr,
                        key,
                        isClose}, this.ExcecuteCmdsOperationCompleted, userState);
        }
        
        private void OnExcecuteCmdsOperationCompleted(object arg) {
            if ((this.ExcecuteCmdsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ExcecuteCmdsCompleted(this, new ExcecuteCmdsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAVXML", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetAVXML(string startCity, string endCity, string flightDate, string startTime, string carrier, string option, string stop, string ABEConnStr) {
            object[] results = this.Invoke("GetAVXML", new object[] {
                        startCity,
                        endCity,
                        flightDate,
                        startTime,
                        carrier,
                        option,
                        stop,
                        ABEConnStr});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetAVXMLAsync(string startCity, string endCity, string flightDate, string startTime, string carrier, string option, string stop, string ABEConnStr) {
            this.GetAVXMLAsync(startCity, endCity, flightDate, startTime, carrier, option, stop, ABEConnStr, null);
        }
        
        /// <remarks/>
        public void GetAVXMLAsync(string startCity, string endCity, string flightDate, string startTime, string carrier, string option, string stop, string ABEConnStr, object userState) {
            if ((this.GetAVXMLOperationCompleted == null)) {
                this.GetAVXMLOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAVXMLOperationCompleted);
            }
            this.InvokeAsync("GetAVXML", new object[] {
                        startCity,
                        endCity,
                        flightDate,
                        startTime,
                        carrier,
                        option,
                        stop,
                        ABEConnStr}, this.GetAVXMLOperationCompleted, userState);
        }
        
        private void OnGetAVXMLOperationCompleted(object arg) {
            if ((this.GetAVXMLCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAVXMLCompleted(this, new GetAVXMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetRawDataFromABE", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetRawDataFromABE(string cmd, string ABEConnStr) {
            object[] results = this.Invoke("GetRawDataFromABE", new object[] {
                        cmd,
                        ABEConnStr});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetRawDataFromABEAsync(string cmd, string ABEConnStr) {
            this.GetRawDataFromABEAsync(cmd, ABEConnStr, null);
        }
        
        /// <remarks/>
        public void GetRawDataFromABEAsync(string cmd, string ABEConnStr, object userState) {
            if ((this.GetRawDataFromABEOperationCompleted == null)) {
                this.GetRawDataFromABEOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRawDataFromABEOperationCompleted);
            }
            this.InvokeAsync("GetRawDataFromABE", new object[] {
                        cmd,
                        ABEConnStr}, this.GetRawDataFromABEOperationCompleted, userState);
        }
        
        private void OnGetRawDataFromABEOperationCompleted(object arg) {
            if ((this.GetRawDataFromABECompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRawDataFromABECompleted(this, new GetRawDataFromABECompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void ExcecuteCmdsCompletedEventHandler(object sender, ExcecuteCmdsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ExcecuteCmdsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ExcecuteCmdsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void GetAVXMLCompletedEventHandler(object sender, GetAVXMLCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAVXMLCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAVXMLCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    public delegate void GetRawDataFromABECompletedEventHandler(object sender, GetRawDataFromABECompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.4927")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRawDataFromABECompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRawDataFromABECompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591