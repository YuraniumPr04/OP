﻿#pragma checksum "..\..\CheckWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7C617DBF137BAA0AA98E7DEB98F246E499289CE07FC196E20C4E2B16685B17D5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Prac_1;
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


namespace Prac_1 {
    
    
    /// <summary>
    /// CheckWindow
    /// </summary>
    public partial class CheckWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\CheckWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_exit;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\CheckWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CountSymbols;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\CheckWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InputField;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\CheckWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CountAttempts;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\CheckWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Variance_Of_Samples;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\CheckWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label P_Identification;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\CheckWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Mistake_1;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\CheckWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Mistake_2;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\CheckWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton Check_author;
        
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
            System.Uri resourceLocater = new System.Uri("/Prac-1;component/checkwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CheckWindow.xaml"
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
            this.btn_exit = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\CheckWindow.xaml"
            this.btn_exit.Click += new System.Windows.RoutedEventHandler(this.btn_exit_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CountSymbols = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.InputField = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\CheckWindow.xaml"
            this.InputField.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.InputField_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CountAttempts = ((System.Windows.Controls.ComboBox)(target));
            
            #line 24 "..\..\CheckWindow.xaml"
            this.CountAttempts.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CountAttempts_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Variance_Of_Samples = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.P_Identification = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Mistake_1 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.Mistake_2 = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.Check_author = ((System.Windows.Controls.RadioButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

