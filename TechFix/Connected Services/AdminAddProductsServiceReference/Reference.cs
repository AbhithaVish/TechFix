﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechFix.AdminAddProductsServiceReference {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AdminAddProductsServiceReference.AdminAddProductsWebServiceSoap")]
    public interface AdminAddProductsWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AutoProductId", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AutoProductId();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AutoProductId", ReplyAction="*")]
        System.Threading.Tasks.Task<string> AutoProductIdAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddProduct", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AddProduct(string productName, decimal productPrice, int productQty, string productDesc, string username, string categoryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddProduct", ReplyAction="*")]
        System.Threading.Tasks.Task<string> AddProductAsync(string productName, decimal productPrice, int productQty, string productDesc, string username, string categoryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCategories", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable GetCategories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetCategories", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetCategoriesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface AdminAddProductsWebServiceSoapChannel : TechFix.AdminAddProductsServiceReference.AdminAddProductsWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AdminAddProductsWebServiceSoapClient : System.ServiceModel.ClientBase<TechFix.AdminAddProductsServiceReference.AdminAddProductsWebServiceSoap>, TechFix.AdminAddProductsServiceReference.AdminAddProductsWebServiceSoap {
        
        public AdminAddProductsWebServiceSoapClient() {
        }
        
        public AdminAddProductsWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AdminAddProductsWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdminAddProductsWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdminAddProductsWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string AutoProductId() {
            return base.Channel.AutoProductId();
        }
        
        public System.Threading.Tasks.Task<string> AutoProductIdAsync() {
            return base.Channel.AutoProductIdAsync();
        }
        
        public string AddProduct(string productName, decimal productPrice, int productQty, string productDesc, string username, string categoryId) {
            return base.Channel.AddProduct(productName, productPrice, productQty, productDesc, username, categoryId);
        }
        
        public System.Threading.Tasks.Task<string> AddProductAsync(string productName, decimal productPrice, int productQty, string productDesc, string username, string categoryId) {
            return base.Channel.AddProductAsync(productName, productPrice, productQty, productDesc, username, categoryId);
        }
        
        public System.Data.DataTable GetCategories() {
            return base.Channel.GetCategories();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetCategoriesAsync() {
            return base.Channel.GetCategoriesAsync();
        }
    }
}
