﻿#pragma checksum "..\..\..\Frames\frMilitaryEquipmentsInMilitaryBase.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7CF190853B2D320FBFF0ADF7AEF9A7F7E2A075F4266389D009B116771E8B161B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MilitaryDistrict_IS.Frames;
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


namespace MilitaryDistrict_IS.Frames {
    
    
    /// <summary>
    /// frMilitaryEquipmentsInMilitaryBase
    /// </summary>
    public partial class frMilitaryEquipmentsInMilitaryBase : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 21 "..\..\..\Frames\frMilitaryEquipmentsInMilitaryBase.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgMilitaryEquipmentsInMilitaryBase;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Frames\frMilitaryEquipmentsInMilitaryBase.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddMilitaryEquipmentsInMilitaryBase;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Frames\frMilitaryEquipmentsInMilitaryBase.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteMilitaryEquipmentsInMilitaryBase;
        
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
            System.Uri resourceLocater = new System.Uri("/MilitaryDistrict-IS;component/frames/frmilitaryequipmentsinmilitarybase.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Frames\frMilitaryEquipmentsInMilitaryBase.xaml"
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
            
            #line 9 "..\..\..\Frames\frMilitaryEquipmentsInMilitaryBase.xaml"
            ((MilitaryDistrict_IS.Frames.frMilitaryEquipmentsInMilitaryBase)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Page_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgMilitaryEquipmentsInMilitaryBase = ((System.Windows.Controls.DataGrid)(target));
            
            #line 21 "..\..\..\Frames\frMilitaryEquipmentsInMilitaryBase.xaml"
            this.dgMilitaryEquipmentsInMilitaryBase.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgMilitaryEquipmentsInMilitaryBase_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddMilitaryEquipmentsInMilitaryBase = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Frames\frMilitaryEquipmentsInMilitaryBase.xaml"
            this.AddMilitaryEquipmentsInMilitaryBase.Click += new System.Windows.RoutedEventHandler(this.AddMilitaryEquipmentsInMilitaryBase_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DeleteMilitaryEquipmentsInMilitaryBase = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Frames\frMilitaryEquipmentsInMilitaryBase.xaml"
            this.DeleteMilitaryEquipmentsInMilitaryBase.Click += new System.Windows.RoutedEventHandler(this.DeleteMilitaryEquipmentsInMilitaryBase_Click);
            
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
            switch (connectionId)
            {
            case 3:
            
            #line 30 "..\..\..\Frames\frMilitaryEquipmentsInMilitaryBase.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditThisMilitaryEquipmentsInMilitaryBase_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

