﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CB2EC53AA574480F78E13B5BB443F14CF203DA7C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace PicDB {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Searchbar;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PicturePreview;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox CameraBox;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PhotogrBox;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSaveGeneralInfo;
        
        #line default
        #line hidden
        
        
        #line 177 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UI_IPTC_Keywords;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UI_IPTC_ByLine;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UI_IPTC_CopyrightNotice;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UI_IPTC_Headline;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UI_IPTC_Caption;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnSaveIPTC;
        
        #line default
        #line hidden
        
        
        #line 276 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PictureSelection;
        
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
            System.Uri resourceLocater = new System.Uri("/PicDB;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
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
            this.Searchbar = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\MainWindow.xaml"
            this.Searchbar.GotFocus += new System.Windows.RoutedEventHandler(this.Searchbar_GotFocus);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\MainWindow.xaml"
            this.Searchbar.LostFocus += new System.Windows.RoutedEventHandler(this.Searchbar_LostFocus);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\MainWindow.xaml"
            this.Searchbar.SelectionChanged += new System.Windows.RoutedEventHandler(this.Searchbar_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PicturePreview = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.CameraBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.PhotogrBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.BtnSaveGeneralInfo = ((System.Windows.Controls.Button)(target));
            
            #line 156 "..\..\..\MainWindow.xaml"
            this.BtnSaveGeneralInfo.Click += new System.Windows.RoutedEventHandler(this.BtnSaveGeneralInfo_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.UI_IPTC_Keywords = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.UI_IPTC_ByLine = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.UI_IPTC_CopyrightNotice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.UI_IPTC_Headline = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.UI_IPTC_Caption = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.BtnSaveIPTC = ((System.Windows.Controls.Button)(target));
            
            #line 204 "..\..\..\MainWindow.xaml"
            this.BtnSaveIPTC.Click += new System.Windows.RoutedEventHandler(this.BtnSaveIPTC_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.PictureSelection = ((System.Windows.Controls.ListBox)(target));
            
            #line 276 "..\..\..\MainWindow.xaml"
            this.PictureSelection.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PictureSelection_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

