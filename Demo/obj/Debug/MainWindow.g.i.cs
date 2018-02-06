﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12208F9FE56320FD4E291EC2315F8EB8480D4883"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Imagin.Common;
using Imagin.Common.Collections;
using Imagin.Common.Data;
using Imagin.Common.Data.Converters;
using Imagin.Common.Debug;
using Imagin.Common.Drawing;
using Imagin.Common.Globalization;
using Imagin.Common.Input;
using Imagin.Common.Linq;
using Imagin.Common.Markup;
using Imagin.Common.Media;
using Imagin.Common.Primitives;
using Imagin.Common.Text;
using Imagin.Controls.Common;
using Imagin.Controls.Common.Converters;
using Imagin.Controls.Common.Interactivity;
using Imagin.Controls.Common.Linq;
using Imagin.NET.Demo;
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


namespace Imagin.NET.Demo {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : Imagin.Controls.Common.BasicWindow, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 19 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Imagin.NET.Demo.MainWindow PART_MainWindow;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PART_ListBox;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Imagin.NET.Demo.ControlView PART_ControlView;
        
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
            System.Uri resourceLocater = new System.Uri("/Imagin.NET.Demo;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.PART_MainWindow = ((Imagin.NET.Demo.MainWindow)(target));
            return;
            case 3:
            this.PART_ListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.PART_ControlView = ((Imagin.NET.Demo.ControlView)(target));
            return;
            case 8:
            
            #line 1428 "..\..\MainWindow.xaml"
            ((Imagin.Controls.Common.Link)(target)).Click += new System.Windows.RoutedEventHandler(this.OnLinkPressed);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 1450 "..\..\MainWindow.xaml"
            ((Imagin.Controls.Common.MaskedButton)(target)).Click += new System.Windows.RoutedEventHandler(this.OnMaskedButtonClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 1691 "..\..\MainWindow.xaml"
            ((Imagin.Controls.Common.SelectionCanvas)(target)).Selected += new System.EventHandler<Imagin.Common.Input.EventArgs<Imagin.Common.Primitives.Selection>>(this.OnSelectionCanvasSelected);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 1936 "..\..\MainWindow.xaml"
            ((Imagin.Controls.Common.TextBox)(target)).Entered += new System.EventHandler<Imagin.Controls.Common.Input.TextSubmittedEventArgs>(this.OnTextBoxEntered);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 2:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Control.MouseDoubleClickEvent;
            
            #line 102 "..\..\MainWindow.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseButtonEventHandler(this.OnMouseDoubleClick);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 5:
            
            #line 400 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnColorSelected);
            
            #line default
            #line hidden
            break;
            case 6:
            
            #line 911 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.OnViewChanged);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 915 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.OnViewChanged);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

