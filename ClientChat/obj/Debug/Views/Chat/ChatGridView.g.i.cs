﻿#pragma checksum "..\..\..\..\Views\Chat\ChatGridView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2842604FD84DDF0EA65BB46774BF19B54064B9CD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SharpChat.Views.Chat;
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


namespace SharpChat.Views.Chat {
    
    
    /// <summary>
    /// ChatGridView
    /// </summary>
    public partial class ChatGridView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\Views\Chat\ChatGridView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl ServerStateLine;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Views\Chat\ChatGridView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl ChatCollection;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\Chat\ChatGridView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl HeadChatLine;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Views\Chat\ChatGridView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl MessagesFeed;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Views\Chat\ChatGridView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl EditChatLine;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Views\Chat\ChatGridView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl MyProfileLine;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Views\Chat\ChatGridView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentControl Target;
        
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
            System.Uri resourceLocater = new System.Uri("/ClientChat;component/views/chat/chatgridview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Chat\ChatGridView.xaml"
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
            this.ServerStateLine = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 2:
            this.ChatCollection = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 3:
            this.HeadChatLine = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 4:
            this.MessagesFeed = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 5:
            this.EditChatLine = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 6:
            this.MyProfileLine = ((System.Windows.Controls.ContentControl)(target));
            return;
            case 7:
            this.Target = ((System.Windows.Controls.ContentControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
