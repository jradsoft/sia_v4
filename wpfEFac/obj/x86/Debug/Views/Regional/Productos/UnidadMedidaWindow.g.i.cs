﻿#pragma checksum "..\..\..\..\..\..\Views\Regional\Productos\UnidadMedidaWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BEC5629E8AD5C06E5AA00A0A908C4B95"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
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
using System.Windows.Forms.Integration;
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


namespace wpfEFac.Views.Productos {
    
    
    /// <summary>
    /// UnidadMedidaWindow
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class UnidadMedidaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\..\..\Views\Regional\Productos\UnidadMedidaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbNombreUnidadMedida;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\..\Views\Regional\Productos\UnidadMedidaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombreUnidadMedida;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\..\..\Views\Regional\Productos\UnidadMedidaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblError;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\..\..\Views\Regional\Productos\UnidadMedidaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bttCancelar;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\..\Views\Regional\Productos\UnidadMedidaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bttnGuardar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/wpfEFac;component/views/regional/productos/unidadmedidawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\Regional\Productos\UnidadMedidaWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txbNombreUnidadMedida = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txtNombreUnidadMedida = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.lblError = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.bttCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\..\..\Views\Regional\Productos\UnidadMedidaWindow.xaml"
            this.bttCancelar.Click += new System.Windows.RoutedEventHandler(this.bttCancelar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.bttnGuardar = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\..\..\Views\Regional\Productos\UnidadMedidaWindow.xaml"
            this.bttnGuardar.Click += new System.Windows.RoutedEventHandler(this.bttnGuardar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

