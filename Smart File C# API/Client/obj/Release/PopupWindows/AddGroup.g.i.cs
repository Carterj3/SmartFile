﻿#pragma checksum "..\..\..\PopupWindows\AddGroup.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F36444972526FBAC9B281A84B5593CD3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Controls;
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


namespace Client {
    
    
    /// <summary>
    /// AddGroup
    /// </summary>
    public partial class AddGroup : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\PopupWindows\AddGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _GroupName;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\PopupWindows\AddGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _Add;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\PopupWindows\AddGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox _AddUser;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\PopupWindows\AddGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _Remove;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\PopupWindows\AddGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox _RemoveUser;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\PopupWindows\AddGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _CreateGroup;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\PopupWindows\AddGroup.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button _Cancel;
        
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
            System.Uri resourceLocater = new System.Uri("/Client;component/popupwindows/addgroup.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PopupWindows\AddGroup.xaml"
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
            
            #line 5 "..\..\..\PopupWindows\AddGroup.xaml"
            ((Client.AddGroup)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this._GroupName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this._Add = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\PopupWindows\AddGroup.xaml"
            this._Add.Click += new System.Windows.RoutedEventHandler(this._Add_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this._AddUser = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this._Remove = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\PopupWindows\AddGroup.xaml"
            this._Remove.Click += new System.Windows.RoutedEventHandler(this._Remove_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this._RemoveUser = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this._CreateGroup = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\PopupWindows\AddGroup.xaml"
            this._CreateGroup.Click += new System.Windows.RoutedEventHandler(this._CreateGroup_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this._Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\PopupWindows\AddGroup.xaml"
            this._Cancel.Click += new System.Windows.RoutedEventHandler(this._Cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

