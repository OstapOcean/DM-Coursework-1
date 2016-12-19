﻿#pragma checksum "..\..\OutputWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E4BAB107C2215532DB332B32C8CCEC4A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DMCP_Part_1;
using GraphX.Controls;
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


namespace DMCP_Part_1 {
    
    
    /// <summary>
    /// OutputWindow
    /// </summary>
    public partial class OutputWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 79 "..\..\OutputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TotalCostText_label;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\OutputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TotalCost_label;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\OutputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CostPreviewBtn;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\OutputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CostLegend_label;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\OutputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GraphX.Controls.ZoomControl zoomLeft;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\OutputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DMCP_Part_1.GArea FlowGraphArea;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\OutputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal GraphX.Controls.ZoomControl zoomRight;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\OutputWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DMCP_Part_1.GArea IncrementalGraphArea;
        
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
            System.Uri resourceLocater = new System.Uri("/DMCP_Part_1;component/outputwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\OutputWindow.xaml"
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
            
            #line 56 "..\..\OutputWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_ResultGraph);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 60 "..\..\OutputWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_NextGraph);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 64 "..\..\OutputWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_PrevGraph);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TotalCostText_label = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.TotalCost_label = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.CostPreviewBtn = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\OutputWindow.xaml"
            this.CostPreviewBtn.Click += new System.Windows.RoutedEventHandler(this.Button_Click_ShowCost);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CostLegend_label = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.zoomLeft = ((GraphX.Controls.ZoomControl)(target));
            return;
            case 9:
            this.FlowGraphArea = ((DMCP_Part_1.GArea)(target));
            return;
            case 10:
            this.zoomRight = ((GraphX.Controls.ZoomControl)(target));
            return;
            case 11:
            this.IncrementalGraphArea = ((DMCP_Part_1.GArea)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

