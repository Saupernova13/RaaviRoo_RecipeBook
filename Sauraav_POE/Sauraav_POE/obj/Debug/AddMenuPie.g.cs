﻿#pragma checksum "..\..\AddMenuPie.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "84679A6DAEB3EDBD6BB1017BA2BD6D5910150BEF033B8C8C5FE3BA780217A288"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Sauraav_POE;
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


namespace Sauraav_POE {
    
    
    /// <summary>
    /// AddMenuPie
    /// </summary>
    public partial class AddMenuPie : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\AddMenuPie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer DisplayViewRecipes_Scroller;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\AddMenuPie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel viewRecipesList_StackPnl;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\AddMenuPie.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox menuNameTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Sauraav_POE;component/addmenupie.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddMenuPie.xaml"
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
            this.DisplayViewRecipes_Scroller = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 2:
            this.viewRecipesList_StackPnl = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.menuNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 78 "..\..\AddMenuPie.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.exitPage);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 94 "..\..\AddMenuPie.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.saveMenuDetals);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
