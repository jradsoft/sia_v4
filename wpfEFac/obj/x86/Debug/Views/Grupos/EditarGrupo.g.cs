﻿#pragma checksum "..\..\..\..\..\Views\Grupos\EditarGrupo.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02EB75FE70E5EE0CCBD88C2F529AAF341E250F08"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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


namespace wpfEFac.Views.Grupos {
    
    
    /// <summary>
    /// EditarGrupo
    /// </summary>
    public partial class EditarGrupo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\..\..\Views\Grupos\EditarGrupo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbNombre;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\Views\Grupos\EditarGrupo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombre;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\..\Views\Grupos\EditarGrupo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbFecha_Creacion;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\Views\Grupos\EditarGrupo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFecha_Creacion;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\Views\Grupos\EditarGrupo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bttGuardar;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\Views\Grupos\EditarGrupo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bttCancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/wpfEFac;component/views/grupos/editargrupo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Grupos\EditarGrupo.xaml"
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
            this.txbNombre = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txtNombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txbFecha_Creacion = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txtFecha_Creacion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.bttGuardar = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\..\Views\Grupos\EditarGrupo.xaml"
            this.bttGuardar.Click += new System.Windows.RoutedEventHandler(this.bttGuardar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.bttCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\..\Views\Grupos\EditarGrupo.xaml"
            this.bttCancelar.Click += new System.Windows.RoutedEventHandler(this.bttCancelar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

