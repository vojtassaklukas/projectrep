﻿#pragma checksum "..\..\..\Windows\ShowPropertyListById.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39C13EF46F15C335F58C0ACD7449D6B0344823AE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MainApplication.Windows;
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


namespace MainApplication.Windows {
    
    
    /// <summary>
    /// ShowPropertyListById
    /// </summary>
    public partial class ShowPropertyListById : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Windows\ShowPropertyListById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelPropertyListInfo;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Windows\ShowPropertyListById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PropertyListInformation;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Windows\ShowPropertyListById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelPropertyListProperties;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Windows\ShowPropertyListById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PropertyListProperties;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Windows\ShowPropertyListById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel StackPanelPropertyListOwners;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Windows\ShowPropertyListById.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PropertyListOwners;
        
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
            System.Uri resourceLocater = new System.Uri("/MainApplication;component/windows/showpropertylistbyid.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\ShowPropertyListById.xaml"
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
            this.StackPanelPropertyListInfo = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.PropertyListInformation = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.StackPanelPropertyListProperties = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.PropertyListProperties = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.StackPanelPropertyListOwners = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.PropertyListOwners = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

