﻿#pragma checksum "..\..\..\_frames\frMilitaryDistrict.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F33E47C971BB47F2C81ABD9D3A7D83014DF601C0418F61B8F17CD2A403000326"
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
    /// frMilitaryDistrict
    /// </summary>
    public partial class frMilitaryDistrict : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\_frames\frMilitaryDistrict.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgMilitaryDistrict;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\_frames\frMilitaryDistrict.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditDistrict;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\_frames\frMilitaryDistrict.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddDistrict;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\_frames\frMilitaryDistrict.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteDistrict;
        
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
            System.Uri resourceLocater = new System.Uri("/MilitaryDistrict-IS;component/_frames/frmilitarydistrict.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\_frames\frMilitaryDistrict.xaml"
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
            this.dgMilitaryDistrict = ((System.Windows.Controls.DataGrid)(target));
            
            #line 16 "..\..\..\_frames\frMilitaryDistrict.xaml"
            this.dgMilitaryDistrict.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgMilitaryDistrict_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.EditDistrict = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.AddDistrict = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\_frames\frMilitaryDistrict.xaml"
            this.AddDistrict.Click += new System.Windows.RoutedEventHandler(this.adReus_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DeleteDistrict = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

