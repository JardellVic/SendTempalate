﻿#pragma checksum "..\..\..\..\Controls\RelacaoWelcome.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FA43D8DAC73055CFC8BF96B54336FDEE02FEF6FE"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using CRM.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace CRM.Controls {
    
    
    /// <summary>
    /// RelacaoWelcome
    /// </summary>
    public partial class RelacaoWelcome : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Controls\RelacaoWelcome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDataInicial;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Controls\RelacaoWelcome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dataInicial;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Controls\RelacaoWelcome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSearch;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\Controls\RelacaoWelcome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExportarExcel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Controls\RelacaoWelcome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar progressBar;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Controls\RelacaoWelcome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotalRecords;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Controls\RelacaoWelcome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTimeEstimate;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CRM;V1.0.2;component/controls/relacaowelcome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\RelacaoWelcome.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lblDataInicial = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.dataInicial = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.btnSearch = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\Controls\RelacaoWelcome.xaml"
            this.btnSearch.Click += new System.Windows.RoutedEventHandler(this.btnSearch_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnExportarExcel = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\Controls\RelacaoWelcome.xaml"
            this.btnExportarExcel.Click += new System.Windows.RoutedEventHandler(this.btnExportarExcel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.progressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 6:
            this.lblTotalRecords = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblTimeEstimate = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

