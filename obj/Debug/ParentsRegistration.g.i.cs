﻿#pragma checksum "..\..\ParentsRegistration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8602EA459310A1CC53E3D36B1762554B75F94DB946D366F24A7D71143BBF2CCB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Student_hostel.UserControls;
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


namespace Student_hostel {
    
    
    /// <summary>
    /// ParentsRegistration
    /// </summary>
    public partial class ParentsRegistration : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\ParentsRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Student_hostel.UserControls.MyTextBox lastname;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\ParentsRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Student_hostel.UserControls.MyTextBox firstname;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\ParentsRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radio1;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\ParentsRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton radio2;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\ParentsRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Student_hostel.UserControls.MyTextBox city;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\ParentsRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock street;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\ParentsRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Student_hostel.UserControls.MyTextBox address;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\ParentsRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Student_hostel.UserControls.MyTextBox house;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\ParentsRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Student_hostel.UserControls.MyTextBox phone;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\ParentsRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Student_hostel.UserControls.MyTextBox workplace;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\ParentsRegistration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Register;
        
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
            System.Uri resourceLocater = new System.Uri("/Student_hostel;component/parentsregistration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ParentsRegistration.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 10 "..\..\ParentsRegistration.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lastname = ((Student_hostel.UserControls.MyTextBox)(target));
            return;
            case 3:
            this.firstname = ((Student_hostel.UserControls.MyTextBox)(target));
            return;
            case 4:
            this.radio1 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.radio2 = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.city = ((Student_hostel.UserControls.MyTextBox)(target));
            return;
            case 7:
            this.street = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.address = ((Student_hostel.UserControls.MyTextBox)(target));
            return;
            case 9:
            this.house = ((Student_hostel.UserControls.MyTextBox)(target));
            return;
            case 10:
            this.phone = ((Student_hostel.UserControls.MyTextBox)(target));
            return;
            case 11:
            this.workplace = ((Student_hostel.UserControls.MyTextBox)(target));
            return;
            case 12:
            this.Register = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\ParentsRegistration.xaml"
            this.Register.Click += new System.Windows.RoutedEventHandler(this.Register_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
