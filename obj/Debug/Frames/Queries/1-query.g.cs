﻿#pragma checksum "..\..\..\..\Frames\Queries\1-query.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A50283FFDBF793508F0B17FA4348C17443FE4672AB2D7EE0BD09167F0FE7ABBF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MilitaryDistrict_IS.Frames.Queries;
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


namespace MilitaryDistrict_IS.Frames.Queries {
    
    
    /// <summary>
    /// _1_query
    /// </summary>
    public partial class _1_query : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\Frames\Queries\1-query.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid queryGrid;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Frames\Queries\1-query.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox availableQueries;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Frames\Queries\1-query.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox availableItems;
        
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
            System.Uri resourceLocater = new System.Uri("/MilitaryDistrict-IS;component/frames/queries/1-query.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Frames\Queries\1-query.xaml"
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
            
            #line 9 "..\..\..\..\Frames\Queries\1-query.xaml"
            ((MilitaryDistrict_IS.Frames.Queries._1_query)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Page_IsVisibleChanged);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\..\Frames\Queries\1-query.xaml"
            ((MilitaryDistrict_IS.Frames.Queries._1_query)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.queryGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 25 "..\..\..\..\Frames\Queries\1-query.xaml"
            this.queryGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.queryGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.availableQueries = ((System.Windows.Controls.ComboBox)(target));
            
            #line 27 "..\..\..\..\Frames\Queries\1-query.xaml"
            this.availableQueries.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.availableQueries_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.availableItems = ((System.Windows.Controls.ComboBox)(target));
            
            #line 41 "..\..\..\..\Frames\Queries\1-query.xaml"
            this.availableItems.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.availabeItems_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

