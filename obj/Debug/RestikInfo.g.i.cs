﻿#pragma checksum "..\..\RestikInfo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "48EF6E086655D2973391EEB2B536D649FD90B1C8ACD5CCEF7E212CE070FB380E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Restik;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Restik {
    
    
    /// <summary>
    /// RestikInfo
    /// </summary>
    public partial class RestikInfo : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\RestikInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridData;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\RestikInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock clientName;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\RestikInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView imageList;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Restik;component/restikinfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RestikInfo.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.gridData = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 37 "..\..\RestikInfo.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackBtnClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 57 "..\..\RestikInfo.xaml"
            ((System.Windows.Controls.Border)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.WatchPlusMouseUp);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 114 "..\..\RestikInfo.xaml"
            ((System.Windows.Controls.Border)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.ClientMouseUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.clientName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            
            #line 130 "..\..\RestikInfo.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BookingClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.imageList = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

