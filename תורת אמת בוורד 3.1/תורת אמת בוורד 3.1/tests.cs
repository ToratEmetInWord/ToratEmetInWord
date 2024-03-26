using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace תורת_אמת_בוורד_3._1
{
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    //The 3 GUIDs in this file need to be unique for your COM object.
    //Generate new ones using Tools->Create GUID in VS2010
    [Guid("4C0ABC5D-E60C-43DA-B75F-A0BAA9FA51B3")]
    // {5BD96ECE-BF42-4BAE-A344-3FB8A1D825FC}

    public interface ICSharpCom
    {
        string Format(string FormatString, [Optional] object arg0, [Optional] object arg1, [Optional] object arg2, [Optional] object arg3);
        void ShowMessageBox(string SomeText);
    }

    //TODO: Change me!
    [Guid("4C0ABC5D-E60C-43DA-B75F-A0BAA9FA51B3")] //Change this 
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    interface ICSharpComEvents
    {
        //Add event definitions here. Add [DispId(1..n)] attributes
        //before each event declaration.
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(ICSharpComEvents))]
    //TODO: Change me!
    [Guid("4C0ABC5D-E60C-43DA-B75F-A0BAA9FA51B3")]
    public sealed class CSharpCom : ICSharpCom
    {
        public string Format(string FormatString, [Optional] object arg0, [Optional] object arg1, [Optional] object arg2, [Optional] object arg3)
        {
            return string.Format(FormatString, arg0, arg1, arg2, arg3);
        }

        public void ShowMessageBox(string SomeText)
        {
            MessageBox.Show(SomeText);
        }
    }
}
