﻿

#pragma checksum "C:\Users\RAJAN\Documents\Visual Studio 2015\Projects\Locare\Locare\SendAndRecieve.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A164A3DF5B8FC6DD73611E3DFE0EFA35"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Locare
{
    partial class SendAndRecieve : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 27 "..\..\SendAndRecieve.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.send_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 32 "..\..\SendAndRecieve.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.recieve_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

